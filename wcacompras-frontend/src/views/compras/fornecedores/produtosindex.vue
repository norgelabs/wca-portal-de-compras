<template>
    <div>
        <bread-crumbs :title="`Itens Fornecedor (${nomeFornecedor})`"
            :custom-button-show="false" :show-button="false"
            :buttons="[{text: 'Importar Produtos', icon:'mdi-upload', event:'importar-click'},
                       {text: 'Exportar Produtos', icon:'mdi-download', event:'exportar-click'},
                       {text: 'Novo', icon:'mdi-plus', event:'novo-click'}]" 
                        @importar-click="importarProduto()"
                        @exportar-click="download()"
                        @novo-click = "openProdutoForm= true"
            />
        <v-row>
            <v-col cols="6">
                <v-text-field label="Pesquisar" placeholder="(Produto)" v-model="filter" density="compact"
                    variant="outlined" color="info">
                </v-text-field>
            </v-col>
        </v-row>
        <v-progress-linear color="primary" indeterminate :height="5" v-show="isBusy || isDownloading"></v-progress-linear>
        <v-table class="elevation-2" v-show="!isBusy">
            <thead>
                <tr>
                    <th class="text-left text-grey">CÓDIGO</th>
                    <th class="text-left text-grey">PRODUTO</th>
                    <th class="text-center text-grey">CATEGORIA</th>
                    <th class="text-left text-grey">VALOR</th>
                    <th class="text-center text-grey">U.M.</th>
                    <th class="text-center text-grey">TAXA</th>
                    <th class="text-center text-grey">%IPI</th>
                    <th class="text-center text-grey">VALOR PRODUTO</th>
                    
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in produtos" :key="item.id">
                    <td class="text-left">{{ item.codigo }}</td>
                    <td class="text-left">{{ item.nome }}</td>
                    <td class="text-center">{{ getTipoFornecimentoNome(item.tipoFornecimentoId) }}</td>
                    <td class="text-right">{{ formatToCurrencyBRL(item.valor.toFixed(2)) }}</td>
                    <td class="text-center">{{ item.unidadeMedida }}</td>
                    <td class="text-right">{{ formatToCurrencyBRL(item.taxaGestao?.toFixed(2)) }}</td>
                    <td class="text-right">{{ item.percentualIPI?.toFixed(2) }} %</td>
                    <td class="text-right">{{ formatToCurrencyBRL(retornarValorTotalProduto(item)) }}</td>
                    <td class="text-right">
                        <v-btn icon="mdi-lead-pencil" variant="plain" color="primary" @click="editar(item)"
                            title="Editar"></v-btn>
                        <v-btn icon="mdi-delete" variant="plain" color="error" @click="remove(item)"></v-btn>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="9">
                        <v-pagination v-model="page" :length="totalPages" :total-visible="4"></v-pagination>
                    </td>
                </tr>
            </tfoot>
        </v-table>
        <v-dialog v-model="openProdutoForm" max-width="900" :absolute="false" persistent>
            <v-form ref="produtoForm" @submit.prevent="salvar()">
                <v-card>
                    <v-card-title class="text-primary text-h5 text-left mb-2 mt-2">
                        {{ produtoFormTitle }}
                    </v-card-title>
                    <v-card-text>
                        <v-row>
                            <v-col cols="4">
                                <v-text-field label="Código" v-model="produto.codigo" type="text" required
                                    variant="outlined" color="primary" :rules="[(v) => !!v || 'Código é obrigatório']"
                                    density="compact">
                                </v-text-field>
                            </v-col>
                            <v-col cols="8">
                                <v-text-field label="Nome" v-model="produto.nome" type="text" required
                                    variant="outlined" color="primary" :rules="[(v) => !!v || 'Nome é obrigatório']"
                                    density="compact">
                                </v-text-field>
                            </v-col>

                        </v-row>
                        <v-row>
                            <v-col>
                                <v-text-field-money label-text="Valor" v-model="produto.valor" color="primary"
                                    :number-decimal="2" :field-rules="produtoValorRules" prefix="R$"></v-text-field-money>
                            </v-col>

                            <v-col>
                                <v-text-field-money label-text="Taxa Gestão" v-model="produto.taxaGestao"
                                    color="primary" :number-decimal="2" prefix="R$"></v-text-field-money>
                            </v-col>
                            <v-col>
                                <v-text-field-money label-text="IPI (%)" v-model="produto.percentualIPI"
                                    color="primary" :number-decimal="2" sufix="%"
                                    :rules="[(v) => parseFloat(v) < 100 || 'O percentual deve ser no máximo 99.99%']"
                                    ></v-text-field-money>
                            </v-col>
                        </v-row>
                        <v-row>
                            <v-col>
                                <v-select label="Categoria" v-model="produto.tipoFornecimentoId" :items="categorias"
                                    density="compact" item-title="text" item-value="value" variant="outlined"
                                    color="primary" :rules="[(v) => !!v || 'Categoria é obrigatória']"></v-select>
                            </v-col>
                            <v-col>
                                <v-text-field label="Unidade Medida" v-model="produto.unidadeMedida" type="text"
                                    required variant="outlined" color="primary"
                                    :rules="[(v) => !!v || 'U.M. é obrigatório']" density="compact">
                                </v-text-field>
                            </v-col>
                            <v-col>
                                <v-text-field label="Valor Total" type="text" prefix="R$"
                                    required variant="outlined" color="primary" :model-value="retornarValorTotalProduto(produto)"
                                    density="compact" :readonly="true" class="right-input">
                                </v-text-field>
                            </v-col>
                        </v-row>
                        
                        <v-row>
                            <v-col class="text-right">
                                <v-btn variant="outlined" color="primary" @click="closeDialog()">Cancelar</v-btn>
                                <v-btn color="primary" type="submit" class="ml-3">Salvar</v-btn>
                            </v-col>
                        </v-row>
                    </v-card-text>
                </v-card>
            </v-form>
        </v-dialog>
    </div>
</template>
  
<script setup>
import { ref, onMounted, watch, inject, computed} from "vue";
import fornecedorService from "@/services/fornecedor.service";
import tipoFornecimentoService from "@/services/tipofornecimento.service";
import handleErrors from "@/helpers/HandleErrors"
import BreadCrumbs from "@/components/breadcrumbs.vue";
import router from "@/router";
import { useRoute } from "vue-router";
import vTextFieldMoney from "@/components/VTextFieldMoney.vue";
import { toBase64, realizarDownload, retornarValorTotalProduto, formatToCurrencyBRL } from "@/helpers/functions";


//DATA
const page = ref(1);
const pageSize = process.env.VUE_APP_PAGE_SIZE;
const isBusy = ref(true);
const totalPages = ref(1);
const produtos = ref([]);
const categorias = ref([]);
const swal = inject("$swal");
const filter = ref("");
const produtoFormTitle = ref("Novo Produto")
const openProdutoForm = ref(false);
const produtoForm = ref(null);
const isDownloading = ref(false)
let idFornecedor = 0;
const route = useRoute();
const produto = ref({
    id: 0,
    fornecedorId: null,
    codigo: null,
    nome: null,
    valor: 0,
    taxaGestao: 0,
    tipoFornecimentoId: null,
    percentualIPI: 0,
    unidadeMedida: ""
})
const produtoValorRules = ref([
    (v) => !!v || 'Valor é obrigatório',
    (v) => parseFloat(v) > 0 || "O campo valor deve ser maior que 0",
]);
let nomeFornecedor = ref("")

//VUE METHODS
onMounted(async () =>
{
    if (parseInt(route.query.fornecedor) > 0)
    {
        idFornecedor = route.query.fornecedor
    }
    await fornecedorService.getById(idFornecedor).then(
        resp => nomeFornecedor.value = resp.data.nome
    ).catch(error =>
    {
        if (error.response.status == 404)
        {
            router.push({ name: "fornecedores" })
        } else
            handleErrors(error)
    })

    await getTipoFornecimentoToList();
    await getItems();
    clearFormData();
});

watch(page, () => getItems());
watch(filter, () => getItems());

//METHODS
function clearFormData()
{
    produto.value = {
        id: 0,
        fornecedorId: idFornecedor,
        codigo: null,
        nome: null,
        valor: 0,
        taxaGestao: 0,
        percentualIPI: 0,
        tipoFornecimentoId: null,
        unidadeMedida: ""
    }
}
function closeDialog()
{
    produtoForm.value.reset();
    clearFormData();
    openProdutoForm.value = false;
}

async function download()
{
    try
    {
        isDownloading.value = true;
        let response = await fornecedorService.produtosExportar(idFornecedor);
        console.log('download', response)
        let nomeArquivo = `WCACompras_${idFornecedor}_Produtos.xlsx`
        realizarDownload(response, nomeArquivo, response.headers.getContentType());

    } catch (error)
    {
        console.log("download.error:", error);
        handleErrors(error)
    } finally
    {
        isDownloading.value = false
    }
}

function editar(item)
{
    produto.value = { ...item }
    produtoFormTitle.value = "Edição de Produto"
    openProdutoForm.value = true;
}

async function getItems()
{
    try
    {
        isBusy.value = true;
        let response = await fornecedorService.produtoPaginate(idFornecedor, pageSize, page.value, filter.value);
        produtos.value = response.data.items;
        totalPages.value = response.data.totalPages;
    } catch (error)
    {
        console.log("produtos.getItems.error:", error.response);
        handleErrors(error)
    } finally
    {
        isBusy.value = false;
    }
}

function getTipoFornecimentoNome(tipoId)
{
    let tipo = categorias.value.filter(t => t.value == tipoId)
    if (tipo.length > 0)
    {
        return tipo[0].text
    }
    return ""
}

async function getTipoFornecimentoToList() 
{
    try
    {
        let response = await tipoFornecimentoService.toList();
        categorias.value = response.data;
    } catch (error)
    {
        console.log("getTipoFornecimentoToList.error:", error);
        handleErrors(error)
    }
}

async function importarProduto()
{
    try
    {
        const { value: file } = await swal.fire({
            title: 'Selecionar planilha',
            input: 'file',
            showCancelButton: true,
            inputAttributes: {
                'accept': 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel',
                'aria-label': 'Selecione a planilha de produtos'
            }
        })

        if (file)
        {
            isBusy.value = true
            console.log(file.name);
            var arquivo = await toBase64(file);
            arquivo = arquivo.split(";")[1].replace('base64,', '');

            let arquivoImportacao = {
                fornecedorId: idFornecedor,
                nomeArquivo: file.name,
                arquivo: arquivo
            }

            await fornecedorService.produtosImportar(arquivoImportacao);

            await getItems();

        }
    } catch (error)
    {
        console.log("importarProduto.error:", error);
        handleErrors(error)
    } finally { isBusy.value = false }

}

async function remove(item)
{
    try
    {
        let options = {
            title: "Confirma Exclusão?",
            text: "Deseja realmente excluir o produto: " + item.nome + "?",
            icon: "question",
            showCancelButton: true,
            confirmButtonText: "Sim",
            cancelButtonText: "Não",
        }

        let response = await swal.fire(options);
        if (response.isConfirmed)
        {
            await fornecedorService.produtoRemove(item.fornecedorId, item.id);

            if (produtos.value.length == 1 && page.value > 1)
            {
                page.value--;
            } else
            {
                await getItems()
            }

            swal.fire({
                toast: true,
                icon: "success",
                position: "top-end",
                title: "Sucesso!",
                text: "Exclusão realizada!",
                showConfirmButton: false,
                timer: 2000,
            })
        }
    } catch (error)
    {
        console.log("produtos.error:", error);
        handleErrors(error)
    }
}

async function salvar()
{
    try
    {
        let { valid } = await produtoForm.value.validate();
        if (valid)
        {
            let data = produto.value;
            if (data.id == 0)
            {
                await fornecedorService.produtoCreate(data);
            } else
            {
                await fornecedorService.produtoUpdate(data);
            }
            await getItems();
            closeDialog();
            swal.fire({
                toast: true,
                icon: "success",
                position: "top-end",
                title: "Sucesso!",
                text: "Dados salvos com sucesso!",
                showConfirmButton: false,
                timer: 2000,
            })
        }
    } catch (error)
    {
        console.log("produtos.error:", error);
        handleErrors(error)
    }
}



</script>

<style scoped>
.right-input :deep() input {
    text-align: right
}
</style>
  
  