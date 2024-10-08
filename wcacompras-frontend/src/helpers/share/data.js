export const TipoSolicitacao = [
  { text: "Desligamento", value: 1 },
  { text: "Comunicado", value: 2 },
  { text: "Férias", value: 3 },
  { text: "Mudança de base", value: 4 },
  { text: "Vaga", value: 5 },
];

//FUNCTIONS

export function getTextFromListByCodigo(list, codigo) {
  let _data = list.find((x) => x.value == codigo);
  return _data ? _data.text : "";
}

export function getPageTitle(solicitacaoTipoId) {
  switch (solicitacaoTipoId) {
    case 1:
      return "Desligamento";
    case 2:
      return "Comunicado";
    case 3:
      return "Férias";
    case 4:
      return "Mudança de Base";
    case 5:
        return "Vagas";
    default:
      return "Solicitação";
  }
}

export function getShareRouteName(solicitacaoTipoId) 
{
  switch (solicitacaoTipoId) {
    case 1:
      return "shareDesligamento";
    case 2:
      return "shareComunicado";
    case 3:
      return "shareFerias";
    case 4:
      return "shareMudancaBase";
    case 5:
        return "shareVaga";
    default:
      return "XXXX";
  }
}



export function getObservacaoLabelDescricao(solicitacaoTipoId) {
  switch (solicitacaoTipoId) {
    case 1:
      return "Observação do Desligamento";
    case 2:
      return "Observação";
    case 3:
      return "Observação Férias";
    case 4:
      return "Observação";
    case 5:
        return "Andamentos";
    default:
      return "Observação";
  }
}
