<template>
  <div>
    <bread-crumbs
      :title="hasPermissionAprovador ? 'Requisições' : 'Minhas Requisições'"
      @novoClick="router.push({ name: 'requisicaoCadastro' })"
      :show-button="authStore.hasPermissao('requisicao')"
      :buttons="headerButtons"
      @gerar-relatorio-click="gerarRelatorio()"
    />
    <v-row>
      <v-col>
        <v-autocomplete
          label="Filiais"
          v-model="filter.filial"
          :items="filiais"
          density="compact"
          item-title="text"
          item-value="value"
          variant="outlined"
          color="primary"
          :hide-details="true"
        >
        </v-autocomplete>
      </v-col>
      <v-col>
        <v-autocomplete
          label="Clientes"
          v-model="filter.clienteId"
          :items="clientes"
          density="compact"
          item-title="text"
          item-value="value"
          variant="outlined"
          color="primary"
          :hide-details="true"
        ></v-autocomplete>
      </v-col>
      <v-col>
        <v-autocomplete
          label="Fornecedor"
          v-model="filter.fornecedorId"
          :items="fornecedores"
          density="compact"
          item-title="text"
          item-value="value"
          variant="outlined"
          color="primary"
          :hide-details="true"
        ></v-autocomplete>
      </v-col>
      <v-col v-show="hasPermissionAprovador">
        <v-autocomplete
          label="Usuário"
          v-model="filter.usuarioId"
          :items="usuarios"
          density="compact"
          item-title="text"
          item-value="value"
          variant="outlined"
          color="primary"
          :hide-details="true"
        ></v-autocomplete>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="4">
        <v-select
          label="Status"
          v-model="filter.status"
          :items="status"
          density="compact"
          item-title="text"
          item-value="value"
          variant="outlined"
          color="primary"
          :hide-details="true"
          multiple
        ></v-select>
      </v-col>
      <v-col cols="2">
        <v-text-field
          label="Data Início"
          v-model="filter.dataInicio"
          type="date"
          variant="outlined"
          color="primary"
          density="compact"
        ></v-text-field>
      </v-col>
      <v-col cols="2">
        <v-text-field
          label="Data Fim"
          v-model="filter.dataFim"
          type="date"
          variant="outlined"
          color="primary"
          density="compact"
        ></v-text-field>
      </v-col>
      <v-col class="text-right">
        <v-btn
          color="primary"
          variant="outlined"
          class="text-capitalize"
          @click="applyFilters(true)"
          title="Aplicar Filtros"
        >
          <!-- <v-icon :icon="customButtonIcon" v-if="customButtonIcon != ''"></v-icon> -->
          <b>Aplicar</b>
        </v-btn>
        &nbsp;
        <v-btn
          color="info"
          variant="outlined"
          class="text-capitalize"
          @click="clearFilters()"
          title="Limpar Filtros"
        >
          <!-- <v-icon :icon="customButtonIcon" v-if="customButtonIcon != ''"></v-icon> -->
          <b>Limpar</b>
        </v-btn>
      </v-col>
    </v-row>
    <br />
    <v-progress-linear
      color="primary"
      indeterminate
      :height="5"
      v-show="isBusy"
    ></v-progress-linear>
    <v-table class="elevation-2">
      <thead>
        <tr>
          <th class="text-center text-grey">PEDIDO</th>
          <th class="text-left text-grey" v-show="hasPermissionAprovador">
            USUÁRIO
          </th>
          <th class="text-center text-grey">DATA</th>
          <th class="text-left text-grey">CLIENTE</th>
          <th class="text-left text-grey">FORNECEDOR</th>
          <th class="text-center text-grey">VALOR</th>
          <th class="text-center text-grey">STATUS</th>
          <th class="text-left text-grey" v-show="hasPermissionAprovador">
            APROVAR
          </th>
          <th class="text-center">
            <v-btn
              class="text-none"
              variant="text"
              title="Visualizar items aprovação"
              @click="openCarrinho = true"
            >
              <v-badge :content="carrinho.length" color="orange">
                <v-icon>mdi-text-box-check-outline</v-icon>
              </v-badge>
            </v-btn>
          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in requisicoes" :key="item.id">
          <td class="text-center"># {{ item.id }}</td>
          <td class="text-left" v-show="hasPermissionAprovador">
            {{ item.usuario.text }}
          </td>
          <td class="text-center">
            {{ new Date(item.dataCriacao).toLocaleDateString() }}
          </td>
          <td class="text-left">{{ item.cliente.nome }}</td>
          <td class="text-left">{{ item.fornecedor.text }}</td>
          <td class="text-right">
            {{
              parseFloat(item.valorTotal.toFixed(2)).toLocaleString("pt-BR", {
                style: "currency",
                currency: "BRL",
              })
            }}
          </td>
          <td class="text-center">
            <v-btn
              :color="getStatus(item.status).color"
              variant="tonal"
              density="compact"
              class="text-center"
            >
              {{ getStatus(item.status).text }}</v-btn
            >
          </td>
          <td class="tex-left" v-show="hasPermissionAprovador">
            <span v-show="item.status == 0 && 
                               ((item.requerAutorizacaoWCA == true && authStore.hasPermissao('aprova_requisicao'))
                            || (item.requerAutorizacaoCliente == true && authStore.hasPermissao('aprova_requisicao_cliente')))
            ">
                <v-checkbox
                v-model="item.aprovar"
                label=""
                color="primary"
                :hide-details="true"
                density="compact"
                @update:model-value="(val) => AdicionarRemoverCarrinho(item, val)"
                ></v-checkbox>
            </span>
          </td>
          <td class="text-right">
            <v-btn
              icon="mdi-content-copy"
              size="smaller"
              variant="plain"
              color="info"
              title="Duplicar"
              @click="duplicar(item)"
              v-show="authStore.hasPermissao('requisicao')"
              :disabled="getStatus(item.status).text == 'Cancelado' || isBusy"
            ></v-btn>
            <v-btn
              icon="mdi-lead-pencil"
              size="smaller"
              variant="plain"
              color="primary"
              @click="editar(item.id)"
              title="Editar"
              :disabled="isBusy"
            ></v-btn>
            <v-btn
              icon="mdi-close-circle-outline"
              size="smaller"
              variant="plain"
              color="error"
              @click="remove(item)"
              title="Cancelar"
              v-show="authStore.hasPermissao('requisicao')"
              :disabled="
                getStatus(item.status).text.toLowerCase() == 'cancelado' ||
                getStatus(item.status).text.toLowerCase() == 'finalizado' ||
                isBusy
              "
            ></v-btn>
          </td>
        </tr>
      </tbody>
      <tfoot>
        <tr>
          <td colspan="9">
            <v-pagination
              v-model="filter.page"
              :length="totalPages"
              :total-visible="4"
            ></v-pagination>
          </td>
        </tr>
      </tfoot>
    </v-table>

    <!--DIALOG PARA EXIBIR ITEMS PARA APROVAÇÃO -->
    <v-dialog
      v-model="openCarrinho"
      :absolute="false"
      scrollable
      width="auto"
      persistent
    >
      <v-card>
        <v-card-title>
          <v-row>
            <v-col>
              <h5>LISTA PARA APROVAÇÃO</h5>
            </v-col>
            <v-col cols="1" class="text-right">
              <v-btn
                variant="plain"
                color="grey"
                @click="openCarrinho = false"
                icon="mdi-close-circle-outline"
              ></v-btn>
            </v-col>
          </v-row>
        </v-card-title>
        <v-card-text>
          <v-table class="elevation-2">
            <thead>
              <tr>
                <th class="text-center text-grey">#</th>
                <th class="text-center text-grey">DATA</th>
                <th class="text-center text-grey">USUÁRIO</th>
                <th class="text-center text-grey">CLIENTE</th>
                <th class="text-center text-grey">FORNECEDOR</th>
                <th class="text-center text-grey">VALOR</th>
              </tr>
            </thead>
            <tbody>
              <template v-for="item in carrinho" :key="item.id">
                <tr>
                  <td class="text-center">{{ item.id }}</td>
                  <td class="text-center">
                    {{ moment(item.dataHora).format("DD/MM/YYYY") }}
                  </td>
                  <td class="text-left">{{ item.usuario }}</td>
                  <td class="text-left">{{ item.cliente }}</td>
                  <td class="text-left">{{ item.fornecedor }}</td>
                  <td class="text-right text-black">
                    {{ formatToCurrencyBRL(item.valorTotal) }}
                  </td>
                </tr>
              </template>
            </tbody>
            <tfoot>
              <tr style="font-weight: 600">
                <td colspan="5" class="text-right">TOTAL:</td>
                <td class="text-right">
                  {{ formatToCurrencyBRL(valorTotalCarrinho) }}
                </td>
              </tr>
            </tfoot>
          </v-table>
        </v-card-text>
        <v-card-actions class="text-right">
          <v-spacer></v-spacer>
          <v-btn
            color="primary"
            variant="plain"
            :disabled="carrinho.length == 0 || isRunningAction"
            @click=" () => {
                 confirmText = 'Deseja realmente aprovar a lista?'
                 confirmAction = 'aprove'
                 confirmDialog=true 
            }" 
          >
            APROVAR
          </v-btn>
          &nbsp;
          <v-btn
            color="primary"
            variant="plain"
            @click=" () => {
                 confirmText = 'Deseja realmente limpar a lista?'
                 confirmAction = 'clean'
                 confirmDialog=true 
            }"
            :disabled="carrinho.length == 0 || isRunningAction"
          >
            LIMPAR
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <v-dialog v-model="confirmDialog" width="auto">
      <v-card
        max-width="400"
        prepend-icon="mdi-comment-question-outline"
        title="Confirmação"
      >
      <v-card-text >
        {{ confirmText }}
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer> 
        <v-btn
            variant="plain"
            
            @click="confirmDialog = false"
            size="smaller"
          >NÃO</v-btn>
          &nbsp;
          <v-btn
            variant="plain"
            @click="executeAction(confirmAction)"
            size="smaller"
          >SIM</v-btn>
        </v-card-actions>
        
      </v-card>
    </v-dialog>
  </div>
</template>

<script setup>
import { ref, onMounted, watch, inject, computed } from "vue";
import requisicaoService from "@/services/requisicao.service";
import handleErrors from "@/helpers/HandleErrors";
import BreadCrumbs from "@/components/breadcrumbs.vue";
import router from "@/router";
import { useAuthStore } from "@/store/auth.store";
import clienteService from "@/services/cliente.service";
import userService from "@/services/user.service";
import fornecedorService from "@/services/fornecedor.service";
import { realizarDownload, status } from "@/helpers/functions";
import moment from "moment";
import filialService from "@/services/filial.service";
import { formatToCurrencyBRL } from "@/helpers/functions";
//DATA
const authStore = useAuthStore();
// const page = ref(1);
const pageSize = process.env.VUE_APP_PAGE_SIZE;
const isBusy = ref(false);
const totalPages = ref(1);
const requisicoes = ref([]);
const clientes = ref([]);
const filiais = ref([]);
const fornecedores = ref([]);
const usuarios = ref([]);
const hasPermissionAprovador = ref(false);
const swal = inject("$swal");
const filter = ref({
  filial: [],
  clienteId: null,
  fornecedorId: null,
  usuarioId: null,
  status: null,
  dataInicio: null,
  dataFim: null,
  page: 1,
});
const fromMounted = ref(false);
const carrinho = ref(
  JSON.parse(localStorage.getItem("requisicoes.aprovar")) || []
);
const openCarrinho = ref(false);
const confirmDialog = ref(false);
const confirmAction = ref("");
const confirmText = ref("");
const isRunningAction = ref(false)
//VUE METHODS
const headerButtons = computed(() => {
  let buttons = [];
  buttons.push({
    text: "Gerar relatório",
    icon: "mdi-microsoft-excel",
    event: "GerarRelatorioClick",
  });
  return buttons;
});

const valorTotalCarrinho = computed(() => {
  let valor = 0;
  carrinho.value.forEach((i) => {
    valor += i.valorTotal;
  });
  return valor;
});

onMounted(async () => {
  hasPermissionAprovador.value =
    authStore.hasPermissao("aprova_requisicao") ||
    authStore.hasPermissao("aprova_requisicao_cliente");
  if (!hasPermissionAprovador.value) {
    filter.value.usuarioId = authStore.user.id;
  }
  await getFiliaisByUser();
  await getClienteToList();
  await getFornecedorToList();
  await getUsuarioToList();
  fromMounted.value = true;
  await getItems();
  fromMounted.value = false;
});

watch(
  () => filter.value.page,
  () => applyFilters()
);
watch(
  () => filter.value.filial,
  async () => {
    if (!fromMounted.value) {
      let _filiais = [];
      if (filter.value.filial != null) _filiais.push(filter.value.filial);
      filter.value.clienteId = null;
      filter.value.fornecedorId = null;
      filter.value.usuarioId = hasPermissionAprovador.value
        ? null
        : authStore.user.id;
      await getClienteToList(_filiais);
      await getFornecedorToList(_filiais);
      await getUsuarioToList(_filiais);
    }
  }
);

//watch(filter.value, () => getItems());

//METHODS
function applyFilters(resetPage = false) {
  if (resetPage) filter.value.page = 1;

  localStorage.setItem(
    "requisicao.index.filters",
    JSON.stringify(filter.value)
  );
  getItems();
}
function clearFilters() {
  filter.value.filial = null;
  filter.value.clienteId = null;
  filter.value.fornecedorId = null;
  filter.value.usuarioId = hasPermissionAprovador.value
    ? null
    : authStore.user.id;
  filter.value.status = null;
  filter.value.dataInicio = null;
  filter.value.dataFim = null;
  filter.value.page = 1;
  localStorage.removeItem("requisicao.index.filters");
  getItems();
}
async function duplicar(item) {
  try {
    let options = {
      title: "Confirmar Duplicação",
      text: `Deseja realmente duplicar a requisição: #${item.id}?`,
      icon: "question",
      showCancelButton: true,
      confirmButtonText: "Sim",
      cancelButtonText: "Não",
    };

    let response = await swal.fire(options);
    if (response.isConfirmed) {
      isBusy.value = true;
      let response = await requisicaoService.duplicate(
        item.id,
        authStore.user.id
      );
      console.log("duplicar.response", response);
      await getItems();
      if (response.data.message == "") {
        swal.fire({
          toast: true,
          icon: "success",
          position: "top-end",
          title: "Sucesso!",
          html: `Requisição duplicada com sucesso!`,
          showConfirmButton: false,
          timer: 2000,
        });
      } else {
        swal.fire({
          icon: "warning",
          title: "Atenção!",
          html: `Requisição duplicada, mas alguns produtos não foram encontrados!<br/><br/> ${response.data.message}`,
          showConfirmButton: true,
        });
      }
    }
  } catch (error) {
    console.log("requisicoes.remove.error:", error);
    handleErrors(error);
  } finally {
    isBusy.value = false;
  }
}
function editar(id) {
  router.push({ name: "requisicaoEdicao", params: { requisicao: id } });
}

async function gerarRelatorio() {
  try {
    isBusy.value = true;
    let filtro = { ...filter.value };

    if (!filtro.filial || filtro.filial.length == 0)
      filtro.filial = filiais.value.map((p) => {
        return p.value;
      });

    if (!authStore.hasPermissao("requisicao_all_users")) {
      filtro.authUserId = authStore.user.id;
    }

    let response = await requisicaoService.gerarRelatorio(filtro);

    if (response.status == 200) {
      let nomeArquivo = `requisicao_relatorio_${moment().format(
        "DDMMYYYY_HHmmSS"
      )}.xlsx`;
      await new Promise((r) => setTimeout(r, 1000));
      realizarDownload(
        response,
        nomeArquivo,
        response.headers.getContentType()
      );
    }
  } catch (error) {
    console.log("requisicoes.gerarRelatorio.error:", error.response);
    handleErrors(error);
  } finally {
    isBusy.value = false;
  }
}

async function getClienteToList(filial = []) {
  try {
    //se tiver permissao para visualizar requisição de todos os usuários, lista todos os clientes
    if (authStore.hasPermissao("requisicao_all_users") || filial.length > 0) {
      let response = await clienteService.toList(filial);
      clientes.value = response.data;
    } else {
      let response = await clienteService.getListByAuthenticatedUser();
      let list = response.data;
      list.forEach((elem) => {
        clientes.value.push({ text: elem.nome, value: elem.id });
      });
    }
  } catch (error) {
    console.log("getClienteToList.error:", error);
    handleErrors(error);
  }
}

async function getFiliaisByUser() {
  try {
    isBusy.value = true;
    let response = await filialService.getListByAuthenticatedUser();
    filiais.value = response.data;
  } catch (error) {
    console.log("clientes.getFiliaisByUser.error:", error.response);
    handleErrors(error);
  } finally {
    isBusy.value = false;
  }
}

async function getItems() {
  try {
    isBusy.value = true;

    let storedFilters =
      JSON.parse(localStorage.getItem("requisicao.index.filters")) || null;
    if (storedFilters) filter.value = storedFilters;

    let response = null;
    let filtro = { ...filter.value };
    if (authStore.hasPermissao("requisicao_all_users")) {
      if (!filtro.filial || filtro.filial.length == 0)
        filtro.filial = filiais.value.map((p) => {
          return p.value;
        });
    } else filtro.authUserId = authStore.user.id;

    response = await requisicaoService.paginate(pageSize, filtro.page, filtro);
    requisicoes.value = checkItemCarrinho(response.data.items);
    totalPages.value = response.data.totalPages;
  } catch (error) {
    console.log("requisicoes.getItems.error:", error.response);
    handleErrors(error);
  } finally {
    isBusy.value = false;
  }
}

function getStatus(codigo) {
  return status.filter((s) => s.value == codigo)[0];
}

async function getUsuarioToList(filial = []) {
  try {
    if (filial.length == 0)
      filial = filiais.value.map((p) => {
        return p.value;
      });

    let response = await userService.toList(filial);
    usuarios.value = response.data;
  } catch (error) {
    console.log("getUsuarioToList.error:", error);
    handleErrors(error);
  }
}

async function getFornecedorToList(filial = []) {
  try {
    if (filial.length == 0)
      filial = filiais.value.map((p) => {
        return p.value;
      });

    let response = await fornecedorService.toList(filial);
    fornecedores.value = response.data;
  } catch (error) {
    console.log("getUsuarioToList.error:", error);
    handleErrors(error);
  }
}

async function remove(item) {
  try {
    let options = {
      title: "Confirmar Cancelamento",
      text: `Deseja realmente cancelar a requisição: #${item.id}?`,
      icon: "question",
      showCancelButton: true,
      confirmButtonText: "Sim",
      cancelButtonText: "Não",
    };

    let response = await swal.fire(options);
    if (response.isConfirmed) {
      isBusy.value = true;
      await requisicaoService.remove(item.id);
      await getItems();

      swal.fire({
        toast: true,
        icon: "success",
        position: "top-end",
        title: "Sucesso!",
        text: "Cancelamento realizado!",
        showConfirmButton: false,
        timer: 2000,
      });
    }
  } catch (error) {
    console.log("requisicoes.remove.error:", error);
    handleErrors(error);
  } finally {
    isBusy.value = false;
  }
}

function AdicionarRemoverCarrinho(item, aproved) {
  if (aproved) {
    let cartItem = {
      id: item.id,
      data: item.dataCriacao,
      cliente: item.cliente.nome,
      usuario: item.usuario.text,
      fornecedor: item.fornecedor.text,
      valorTotal: item.valorTotal,
    };
    carrinho.value.push(cartItem);
  } else {
    let index = carrinho.value.findIndex((q) => q.id == item.id);
    if (index != -1) carrinho.value.splice(index, 1);
  }
  localStorage.setItem("requisicoes.aprovar", JSON.stringify(carrinho.value));
}

function checkItemCarrinho(items) {
  items.forEach((item) => {
    if (carrinho.value.findIndex((q) => q.id == item.id) > -1)
      item.aprovar = true;
    else item.aprovar = false;
  });
  return items;
}

async function limparCarrinho() {
    carrinho.value = [];
    requisicoes.value.forEach((item) => (item.aprovar = false));
    localStorage.setItem("requisicoes.aprovar", JSON.stringify(carrinho.value));
}

async function aprovarCarrinho() {
    try {
        isRunningAction.value = true
        for (let index = 0; index < carrinho.value.length; index++)
        {
            let item = carrinho.value[index];
            let data = {
                id: item.id,
                aprovado: true,
                comentario: "",
                token: "TELAEDICAO",
                nomeUsuario: authStore.user.nome,
                WCA: authStore.hasPermissao("aprova_requisicao"),
                Cliente: authStore.hasPermissao("aprova_requisicao_cliente")
            };
            await requisicaoService.aprovar(data);
        }
        limparCarrinho();
        getItems()
    } catch (error) {
        console.error("aprovar.carrinho.error", error);
        handleErrors(error)
    } finally {
        isRunningAction.value = false
    }
}

function executeAction(action) {
    confirmDialog.value = false
    if (action == "clean")    
        limparCarrinho();
    else
        aprovarCarrinho();
}
</script>
