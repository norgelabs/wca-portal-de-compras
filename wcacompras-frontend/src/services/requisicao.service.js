import api from "./api"
import { route } from "./routeDictionary";

export default {

    aprovar(data)
    {
        return api.post(route.requisicaoAprovar, data);
    },
    create(requisicao)
    {
        return api.post(route.requisicaoCreate, requisicao);
    },
    duplicate (id) 
    {
        return api.put(route.requisicaoDuplicate.replace("{id}", id));
    },
    
    finalizarPedido(data)
    {
        return api.post(route.requisicaoFinalizar, data);
    },

    remove (id) 
    {
        return api.delete(route.requisicaoRemove, { params: {"id": id } });
    },
    getById (id) 
    {
        return api.get(route.requisicaoGetById.replace("{id}", id));
    },
    getByToken (token) 
    {
        return api.get(route.requisicaoGetByToken.replace("{token}", token));
    },
    
    update(requisicao)
    {
        return api.put(route.requisicaoUpdate, requisicao);
    },

    paginate(pageSize, page, filters)
    {
        let url = route.requisicaoPaginate.replace("{pageSize}", pageSize).replace("{page}", page)
        return api.get(url, {params: { ...filters }} );
    },

    paginateByUserContext(pageSize, page, filters)
    {
        let url = route.requisicaoPaginateByContextUser.replace("{pageSize}", pageSize).replace("{page}", page)
        return api.get(url, {params: { ...filters }} );
    },

    downloadById()
    {
        return api.get(route.requisicaoDownloadById, { responseType: 'blob'});
    },
    downloadByToken(token)
    {
        return api.get(route.requisicaoDownloadByToken.replace('{token}',token), { responseType: 'blob'});
    },

    enviarEmail(requisicaoId, destinoEmail)
    {
        return api.put(route.requisicaoEnviarEmail.replace("{requisicaoId}", requisicaoId).replace("{destinoEmail}", destinoEmail));
    },

    gerarRelatorio(filters)
    {
        return api.get(route.requisicaoGerarRelatorio, {params: { ...filters }, responseType: 'blob'});
    },

}