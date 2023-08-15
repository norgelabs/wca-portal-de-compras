export const route = {
    login: "/Authentication/Autenticar",
    recuperarSenha: "Authentication/RecuperarSenha",
    alterarSenha: "Authentication/AlterarSenha",
    
    clienteCreate: "Cliente",
    clienteUpdate: "Cliente",
    clienteRemove: "Cliente",
    clienteGetById: "Cliente/{id}",
    clienteToList: "Cliente/ToList/{filial}",
    clientePaginate: "Cliente/Paginate/{pageSize}/{page}",
    clienteListByAuthenticatedUser: "Cliente/ListByAuthenticatedUser",
    clienteImportar: "Cliente/ImportFromExcel",

    configuracaoGetAll: "configuracao",
    configuracaoUpdate: "configuracao",

    filialCreate: "Filial",
    filialUpdate: "Filial",
    filialToList: "Filial/ToList",
    filialPaginate: "Filial/Paginate/{pageSize}/{page}",

    fornecedorCreate: "Fornecedor",
    fornecedorUpdate: "Fornecedor",
    fornecedorRemove: "Fornecedor",
    fornecedorGetById: "Fornecedor/{id}",
    fornecedorToList: "Fornecedor/ToList/{filial}",
    fornecedorPaginate: "Fornecedor/Paginate/{pageSize}/{page}",


    perfilCreate: "Perfil",
    perfilUpdate: "Perfil",
    perfilPaginate: "Perfil/Paginate/{sistemaId}/{pageSize}/{page}",
    perfilToList: "Perfil/ToList/{sistemaId}",
    perfilGetWithPermissions: "Perfil/{id}",
    perfilGetByUserAndSistemaWithPermissions: "Perfil/{usuarioId}/{sistemaId}",
    permissaoToList: "Permissao/ToList/{sistemaId}",
    permissaoAll: "Permissao/all/{sistemaId}",

    produtoCreate: "Fornecedor/Produto",
    produtoUpdate: "Fornecedor/Produto",
    produtoRemove: "Fornecedor/Produto",
    produtoImportFromExcel: "Fornecedor/Produtos/ImportFromExcel",
    produtoExportExcel: "Fornecedor/{fornecedorId}/Produtos/ExportExcel",
    produtoGetById: "Fornecedor/{fornecedorId}/Fornecedor/{id}",
    produtoPaginate: "Fornecedor/{fornecedorId}/Produtos/Paginate/{pageSize}/{page}",
    produtoListWithIcms: "Fornecedor/{fornecedorId}/Produtos/{uf}",

    recorrenciaCreate: "Recorrencia",
    recorrenciaGetById: "Recorrencia/{id}",
    recorrenciaPaginateLogs: "Recorrencia/Log/{id}/{pageSize}/{page}",
    recorrenciaEnabledDisabled: "Recorrencia/EnabledDisabled",
    recorrenciaUpdate: "Recorrencia",
    recorrenciaPaginate: "Recorrencia/Paginate/{pageSize}/{page}",
    
    requisicaoAprovar: "Requisicao/AprovarReprovar",
    requisicaoCreate: "Requisicao",
    requisicaoGetById: "Requisicao/{id}",
    requisicaoGetByToken: "Requisicao/GetByToken/{token}",
    requisicaoRemove: "Requisicao",
    requisicaoDuplicate: "Requisicao/Duplicate/{id}",
    requisicaoUpdate: "Requisicao",
    requisicaoPaginate: "Requisicao/Paginate/{pageSize}/{page}",
    requisicaoDownloadById: "Requisicao/ExportExcel/{id}",
    requisicaoDownloadByToken: "Requisicao/ExportExcel/{token}",
    requisicaoFinalizar: "Requisicao/FinalizarPedido",
    requisicaoEnviarEmail: "Requisicao/SolicitarAprovacao/{requisicaoId}/{destinoEmail}",
    requisicaoGerarRelatorio: "Requisicao/GerarRelatorio",
    

    tipoFornecimentoCreate: "TipoFornecimento",
    tipoFornecimentoUpdate: "TipoFornecimento",
    tipoFornecimentoToList: "TipoFornecimento/ToList",
    tipoFornecimentoPaginate: "TipoFornecimento/Paginate/{pageSize}/{page}",

    usuarioCreate: "Usuario",
    usuarioGetById: "Usuario/{id}/{sistemaId}",
    usuarioRemove: "Usuario",
    usuarioUpdate: "Usuario/{sistemaId}",
    usuarioPaginate: "Usuario/Paginate/{sistemaId}/{pageSize}/{page}",
    usuarioToList: "Usuario/ToList/{sistemaId}",
    usuarioToListByPerfil: "Usuario/ToListByPerfil/{perfilId}",
}