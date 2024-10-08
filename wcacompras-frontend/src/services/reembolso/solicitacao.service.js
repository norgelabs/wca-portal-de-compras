import api from "./api"

const rotas = {
    Create: "Solicitacao",
    Update: "Solicitacao",
    GetById: "Solicitacao",
    Paginar: "Solicitacao/Paginar",
    ListarPorColaboradorGestor: "Solicitacao/ListarPorColaborador",
    ListarStatusSolicitacao: "Solicitacao/ListarStatusSolicitacao",
    AlterarStatus: "Solicitacao/AlterarStatus",
    RegistrarEvento: "Solicitacao/RegistrarEvento",
    ChecaSeDespesaExiste: "Solicitacao/ChecarSeDespesaExiste",
    ExportarParaExcel: "Solicitacao/ExportarParaExcel",
    DespesaCreate: "Solicitacao/Despesa",
    DespesaUpdate: "Solicitacao/Despesa",
    DespesaDelete: "Solicitacao/Despesa/{Id}",
    DespesasToZip: "Solicitacao/{Id}/DespesasToZip"
}

export default {
    changeStatus (data) {
        return api.put(rotas.AlterarStatus, data);
    },
    create(data)
    {
        return api.post(rotas.Create, data);
    },
    getById (id) 
    {
        return api.get(rotas.GetById, {params: {id: id}});
    },
    update(data)
    {
        return api.put(rotas.Update, data);
    },

    ListarPorColaboradorGestor(colaboradorId = 0, status = [])
    {
        let parametros ={
            params: {
                colaboradorId: colaboradorId,
                status: status
            }
        }
        return api.get(rotas.ListarPorColaboradorGestor, parametros);
    },

    ListarStatusSolicitacao()
    {
        return api.get(rotas.ListarStatusSolicitacao);
    },

    paginate(page = 1, pageSize = 10, filters)   {
        
        let parametros = {
            page: page,
            pageSize: pageSize,
            filialId: filters.filialId,
            usuarioId: filters.usuarioId,
            clienteId: filters.clienteId,
            dataIni: filters.dataIni,
            dataFim: filters.dataFim,
            status: filters.status,
            centroCustoIds: filters.centroCustoIds
        }
        return api.get(rotas.Paginar, {params: parametros} );
    },
    registrarEvento(evento) {
        return api.post(rotas.registrarEvento, evento);  
    },
    despesaChecaSeExiste(cnpj, numeroFiscal, despesaId = 0) {

        let query = {
            CNPJ: cnpj,
            notaFiscal: numeroFiscal,
            despesaId: despesaId
        }

        return api.get(rotas.ChecaSeDespesaExiste, {params: query})
    },
    exportarParaExcel(filters)   {
        return api.get(rotas.ExportarParaExcel, {params: filters, responseType: 'blob'} );
    },
    despesaCreate(despesa) {
        return api.post(rotas.DespesaCreate, despesa)
    },
    despesaUpdate(despesa) {
        return api.put(rotas.DespesaUpdate, despesa)
    },
    despesaDelete(despesaId) {
        return api.delete(rotas.DespesaDelete.replace("{Id}", despesaId))
    },
    despesasToZipFile(solicitacaoId) {
        return api.get(rotas.DespesasToZip.replace("{Id}", solicitacaoId), {responseType: 'arraybuffer'})
    }
}