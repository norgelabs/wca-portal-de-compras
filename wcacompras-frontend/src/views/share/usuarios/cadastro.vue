<template>
  <div>
    <Breadcrumbs title="Usuário" :show-button="false" />
    <v-progress-linear
      color="primary"
      indeterminate
      :height="5"
      v-show="isBusy"
    ></v-progress-linear>
    <v-container class="justify-center">
      <v-card>
        <v-card-text>
          <v-form @submit.prevent="salvar()" ref="userForm">
            <usuario-form :user="usuario" :list-filial="filiais" @emailChange="checkUserExistsByEmail($event)"></usuario-form>
            <v-row style="margin-top: 3px;">
              <v-col>
                <v-switch
                v-model="usuarioConfiguracoes.notificarPorEmail"
                color="primary"
                hide-details
                label="Receber notificação por e-mail?"
              />
              </v-col>
              <v-col>
                <v-switch v-show="false"
                v-model="usuarioConfiguracoes.notificarPorChatBot"
                color="primary"
                hide-details
                label="Receber notificação por chatbot?"
              />
              </v-col>
            </v-row>
            <v-row style="margin-top: 3px;">
              <v-col>
                <v-select
                  label="Filial"
                  :model-value="getFilialUsuario()"
                  :items="filiais"
                  item-title="text"
                  item-value="value"
                  variant="outlined"
                  color="primary"
                  :rules="[(v) => !!v || 'Filial é obrigatória']"
                  density="compact"
                  @update:model-value="setFilialUsuario($event)"
                  :disabled="!isMatriz"
                ></v-select>
              </v-col>
              <v-col>
                <v-select
                  label="Perfil"
                  :model-value="getSistemaPerfil(authStore.sistema.id)"
                  :items="listPerfil"
                  item-title="text"
                  item-value="value"
                  variant="outlined"
                  color="primary"
                  :rules="[(v) => !!v || 'Perfil é obrigatório']"
                  density="compact"
                  @update:model-value="setPerfilUsuario($event)"
                ></v-select>
              </v-col>
            </v-row>
            <box-transfer 
              :list-origem="clientes" 
              :list-destino="usuario.cliente"
              list-origem-titulo = "Selecione os clientes"
              list-destino-titulo = "Clientes do usuário"
            />
            <br />
            <box-transfer
              :list-origem="centros"
              :list-destino="usuario.centroCusto"
              list-origem-titulo="Selecione o(s) Centro(s) de Custo"
              list-destino-titulo="Centro(s) de Custo do usuário"
            />
            <v-row style="margin-top: 5px;">
              <v-col class="text-right">
                <v-btn variant="outlined" color="primary" @click="router.go(-1)"
                  >Cancelar</v-btn
                >
                <v-btn color="primary" type="submit" class="ml-3">Salvar</v-btn>
              </v-col>
            </v-row>
          </v-form>
        </v-card-text>
      </v-card>
    </v-container>
  </div>
</template>

<script setup>
import { ref, onMounted, watch, inject } from "vue";
import perfilService from "@/services/perfil.service";
import filialService from "@/services/filial.service";
import clienteService from "@/services/share/cliente.service";
import handleErrors from "@/helpers/HandleErrors";
import { useAuthStore } from "@/store/auth.store";
import { useRoute } from "vue-router";
import router from "@/router"
import Breadcrumbs from "@/components/breadcrumbs.vue";
import usuarioForm from "@/components/usuarioForm.vue";
import boxTransfer from "@/components/boxTransfer.vue";
import { Usuario, useShareUsuarioStore } from "@/store/share/usuario.store";
import userService from "@/services/user.service";
import { useShareClienteStore } from "@/store/share/cliente.store";

//DATA
const isBusy = ref(false);
const listPerfil = ref([]);
const filiais = ref([]);
const clientes = ref([]);
const swal = inject("$swal");
const route = useRoute();
const usuario = ref(new Usuario());
const usuarioStore = useShareUsuarioStore();
let filialUsuario = [];
const authStore = useAuthStore();
const userForm = ref(null);
const tipos = ref([]);
const usuarioConfiguracoes = ref({
  usuarioId: 0,
  sistemaId: authStore.sistema.id,
  notificarPorEmail: false,
  notificarPorChatBot: false
})
const centros = ref([]);
const clientesUsuarios = ref([])
const isMatriz = ref(false)
//VUE METHODS
onMounted(async () => {
  isMatriz.value = authStore.sistema.isMatriz;
  authStore.user.filial = authStore.sistema.filial.value;
  clearData();
  await getFilialToList();
  await getPerfilToList();
  if (parseInt(route.query.id) > 0) {
    await getUsuario(route.query.id);
  }
  isBusy.value = false;
});

watch(
  () => usuario.value.filial,
  async (newfilials) => {
    if (newfilials.length> 0) {

      let objA = JSON.parse(JSON.stringify(newfilials))
      if (objA.length > 0) objA.forEach(e => delete e.selected)
      let objB = JSON.parse(JSON.stringify(filialUsuario))
      if (objB.length > 0) objB.forEach(e => delete e.selected)

      if (JSON.stringify(objA) !== JSON.stringify(objB)) {
        clientes.value = [];
        await getClienteToList(newfilials.map(p =>  {return p.value}));
        clientesListRemove();
        let listIds = newfilials.map((p) =>{ return p.value})
        let remove = filialUsuario.length>0 ? filialUsuario.filter(p => !listIds.includes(p.value)):[]
        usuarioRemoveClienteFromFilial(remove.map(p => {return p.value}))
        filialUsuario = JSON.parse(JSON.stringify(newfilials));
      }
    }else {
      clientes.value = [];
      usuarioRemoveClienteFromFilial(filiais.value.map(q =>  {return q.value}))
    }
  },
  {deep: true}
);

watch( 
  () => usuario.value.cliente,
  async (newClientes) => {
      if (newClientes.length > 0) {
        let objA = JSON.parse(JSON.stringify(newClientes));
        if (objA.length > 0) objA.forEach((e) => delete e.selected);
        let objB = JSON.parse(JSON.stringify(clientesUsuarios.value));
        if (objB.length > 0) objB.forEach((e) => delete e.selected);

        if (JSON.stringify(objA) !== JSON.stringify(objB)) {
          //carregar os centros de custos
          centros.value = await useShareClienteStore().ListCentrosDeCusto(newClientes.map((p) => { return p.value;}));
          
          //remover o que estiver no usuario
          centroCustoListRemove();

          //pega a lista de id dos clientes selecionados
          let listIds = newClientes.map((p) =>{ return p.value})
          console.log("clientes selecionados: ",listIds)

          //pega a lista de ids que foram removidos
          let listToRemove = clientesUsuarios.value.length > 0 ? clientesUsuarios.value.filter(p => !listIds.includes(p.value)):[]
          console.log("clientes removidos: ",listToRemove)

          // remover os centros de custo do cliente removido da lista do usuario
          usuarioRemoveCentroCusto(listToRemove.map(p => {return p.value}))
          
          clientesUsuarios.value = JSON.parse(JSON.stringify(newClientes));
        }
      } else {
        centros.value = [];
        usuarioRemoveCentroCusto(clientesUsuarios.value.map(p => {return p.value}))
        clientesUsuarios.value =[]
      }
  },
  { deep: true }
);



//METHODS
function getFilialUsuario() {
  if (usuario.value.filial.length > 0) {
    return usuario.value.filial[0].value;
  }
  return null;
}

async function setFilialUsuario(filialId) {
  let _filial = filiais.value.find((q) => q.value == filialId);
  if (_filial) {
    usuario.value.filial = [];
    usuario.value.filial.push(_filial);
    usuario.value.cliente = [];
    colaboradorClienteId.value = null;
    await getClienteToList(_filial.value);
  }
}

function setPerfilUsuario(perfilId) {
  let index = -1;
  if ( usuario.value.usuarioSistemaPerfil.length > 0) {
    index = usuario.value.usuarioSistemaPerfil.findIndex(c => c.sistemaId == authStore.sistema.id)
  }
  
  if (index != -1) {
    usuario.value.usuarioSistemaPerfil[index].perfilId = perfilId
  }else {
    usuario.value.usuarioSistemaPerfil.push({
      "sistemaId": authStore.sistema.id,
      "perfilId": perfilId 
    });
  }
}

function usuarioRemoveClienteFromFilial(filialToRemove =[]) 
{
  let removeCliente = usuario.value.cliente.filter(q =>  filialToRemove.includes(q.filialId));
  removeCliente.forEach(r => {
    let index = usuario.value.cliente.findIndex(q =>  q.value == r.value);
    usuario.value.cliente.splice(index, 1);
  })
 
}


function clientesListRemove(removerTodos = false) {
  if (removerTodos == true) clientes.value.splice(0, clientes.value.length);
  else {
    usuario.value.cliente.forEach((cliente) => {
      let index = clientes.value.findIndex((c) => c.value == cliente.value);
      if (index > -1) clientes.value.splice(index, 1);
    });
  }
}

function getSistemaPerfil(sistemaId) {
  let perfilUsuario = undefined
  if (usuario.value.usuarioSistemaPerfil != undefined && usuario.value.usuarioSistemaPerfil.length> 0)
    perfilUsuario = usuario.value.usuarioSistemaPerfil.filter(c => c.sistemaId == sistemaId)[0]
  
  return perfilUsuario == undefined? null: perfilUsuario.perfilId;
  
}

async function salvar() {
  try {
    let { valid } = await userForm.value.validate();
    if (valid) {
      let data = {... usuario.value };
      data.usuarioConfiguracoes[0] = usuarioConfiguracoes.value
      if (data.id == 0) {
        await usuarioStore.add(data);
      } else {
        await usuarioStore.update(data);
      }

      swal.fire({
        toast: true,
        icon: "success",
        position: "top-end",
        title: "Sucesso!",
        text: "Dados salvos com sucesso!",
        showConfirmButton: false,
        timer: 2000,
      });
      router.push({name:"shareUsuarios"})
    }
  } catch (error) {
    console.log("share.usuarios.error:", error);
    handleErrors(error);
  }
}

async function clearData() {
  usuario.value = new Usuario();
  filialUsuario = [];
  await getClienteToList(filialUsuario);
}

async function getClienteToList(filial) {
  try {
    if (filial.length> 0) {
      let response = await clienteService.toList(filial);
      clientes.value = response.data;
    }
      
  } catch (error) {
    console.log("getClienteToList.error:", error);
    handleErrors(error);
  }
}

async function getPerfilToList() {
  try {
    let response = await perfilService.toList();
    listPerfil.value = response.data;
  } catch (error) {
    console.log("getPerfilToList.error:", error);
    handleErrors(error);
  }
}

async function getFilialToList() {
  try {
    let response = await filialService.toList();
    filiais.value = response.data;
  } catch (error) {
    console.log("getFilialToList.error:", error);
    handleErrors(error);
  }
}

async function getUsuario(usuarioId) {
  try {
    debugger
    isBusy.value = true;
    usuario.value = await usuarioStore.getById(usuarioId);
    if (usuario.value.usuarioConfiguracoes.length > 0)
      usuarioConfiguracoes.value = {...usuario.value.usuarioConfiguracoes[0]}

    clientesListRemove();
  } catch (error) {
    console.log("getUsuario.error:", error);
    handleErrors(error);
  } finally {
    isBusy.value = false;
  }
}

// function filiaisListRemove(removerTodos = false) {
//   if (removerTodos == true) tipos.value.splice(0, clientes.value.length);
//   else {
//     usuario.value.filial.forEach((tipo) => {
//       let index = filiais.value.findIndex((c) => c.value == tipo.value);
//       if (index > -1) filiais.value.splice(index, 1);
//     });
//   }
// }

async function checkUserExistsByEmail(email) {
  try {
    let user = (await userService.getByEmail(email)).data;
    let hasUserInTheSameSystem = user.usuarioSistemaPerfil.filter(x => x.sistemaId == authStore.sistema.id)
    console.log('hasUserInTheSameSystem', hasUserInTheSameSystem)
    if (hasUserInTheSameSystem.length > 0 && usuario.value.id == 0) {
      throw new Error("Email já cadastrado, neste sistema!")
    }
    usuario.value.id = user.id
    usuario.value.nome = user.nome
    usuario.value.celular = user.celular

  } catch (error) {
    if( !error.response || error.response.status != 404)
      handleErrors(error)
  }
  
}

function centroCustoListRemove(removerTodos = false) {
  if (removerTodos == true) centros.value.splice(0, centros.value.length);
  else {
    usuario.value.centroCusto.forEach((cc) => {
      let index = centros.value.findIndex((c) => c.value == cc.value);
      if (index > -1) centros.value.splice(index, 1);
    });
  }
}

function usuarioRemoveCentroCusto(clientesToRemove = []) {
  let removeList = usuario.value.centroCusto.filter(q =>  clientesToRemove.includes(q.clienteId));
  removeList.forEach(r => {
    let index = usuario.value.centroCusto.findIndex(q =>  q.value == r.value);
    usuario.value.centroCusto.splice(index, 1);
  })
}



</script>

<style scoped>
.v-list {
  height: 145px;
  /* or any height you want */
  overflow-y: auto;
}

.v-icon:hover {
  cursor: pointer;
}
</style>
