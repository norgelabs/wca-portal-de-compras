export const status = [
    // { value: -1, text: "Todos" },
    { value: 0, text: "Aguardando", color: "warning" },
    { value: 1, text: "Aprovado", color: "success" },
    { value: 2, text: "Rejeitado", color: "error" },
    { value: 3, text: "Finalizado", color: "success" },
    { value: 4, text: "Cancelado", color: "error" }
]


export const tipoRecorrencia = [
    { value: 0, text: "Semanal" },
    { value: 1, text: "Mensal" },
]

export const tipoReembolso = [
    { value: 2, text: "Adiantamento" },
    { value: 1, text: "Reembolso" },
]

export const periodosDia = ['Manhã','Tarde','Noite']

export const diasDaSemana = [
    { value: 0, text: "Domingo" },
    { value: 1, text: "Segunda" },
    { value: 2, text: "Terça" },
    { value: 3, text: "Quarta" },
    { value: 4, text: "Quinta" },
    { value: 5, text: "Sexta" },
    { value: 6, text: "Sábado" },
]

export const diasDoMes = [
    { value: 1, text: "01" },
    { value: 2, text: "02" },
    { value: 3, text: "03" },
    { value: 4, text: "04" },
    { value: 5, text: "05" },
    { value: 6, text: "06" },
    { value: 7, text: "07" },
    { value: 8, text: "08" },
    { value: 9, text: "09" },
    { value: 10, text: "10" },
    { value: 11, text: "11" },
    { value: 12, text: "12" },
    { value: 13, text: "13" },
    { value: 14, text: "14" },
    { value: 15, text: "15" },
    { value: 16, text: "16" },
    { value: 17, text: "17" },
    { value: 18, text: "18" },
    { value: 19, text: "19" },
    { value: 20, text: "20" },
    { value: 21, text: "21" },
    { value: 22, text: "22" },
    { value: 23, text: "23" },
    { value: 24, text: "24" },
    { value: 25, text: "25" },
    { value: 26, text: "26" },
    { value: 27, text: "27" },
    { value: 28, text: "28" },
    { value: 29, text: "29" },
    { value: 30, text: "30" },
    { value: 31, text: "31" },
]

export const TipoCampo = [
    {value: 1, text: 'bool'},
    {value: 2, text: 'text'},
    {value: 3, text: 'number'},
    {value: 4, text: 'decimal'},
    {value: 5, text: 'combo'},
]

export const Estados = [
    {value: 'AC', text: 'Acre'},
    {value: 'AL', text: 'Alagoas'},
    {value: 'AP', text: 'Amapá'},
    {value: 'AM', text: 'Amazonas'},
    {value: 'BA', text: 'Bahia'},
    {value: 'CE', text: 'Ceará'},
    {value: 'DF', text: 'Distrito Federal'},
    {value: 'ES', text: 'Espírito Santo'},
    {value: 'GO', text: 'Goiás'},
    {value: 'MA', text: 'Maranhão'},
    {value: 'MT', text: 'Mato Grosso'},
    {value: 'MS', text: 'Mato Grosso do Sul'},
    {value: 'MG', text: 'Minas Gerais'},
    {value: 'PA', text: 'Pará'},
    {value: 'PB', text: 'Paraíba'},
    {value: 'PR', text: 'Paraná'},
    {value: 'PE', text: 'Pernambuco'},
    {value: 'PI', text: 'Piauí'},
    {value: 'RJ', text: 'Rio de Janeiro'},
    {value: 'RN', text: 'Rio Grande do Norte'},
    {value: 'RS', text: 'Rio Grande do Sul'},
    {value: 'RO', text: 'Rondônia'},
    {value: 'RR', text: 'Roraima'},
    {value: 'SC', text: 'Santa Catarina'},
    {value: 'SP', text: 'São Paulo'},
    {value: 'SE', text: 'Sergipe'},
    {value: 'TO', text: 'Tocantins'}
]


export const compararValor = function (key, order = "asc") {
    return function (a, b) {
        if (!a.hasOwnProperty(key) || !b.hasOwnProperty(key)) {
            // property doesn't exist on either object
            return 0;
        }

        const varA = typeof a[key] === "string" ? a[key].toUpperCase() : a[key];
        const varB = typeof b[key] === "string" ? b[key].toUpperCase() : b[key];

        let comparison = 0;
        if (varA > varB) {
            comparison = 1;
        } else if (varA < varB) {
            comparison = -1;
        }
        return order == "desc" ? comparison * -1 : comparison;
    };
};

export const toBase64 = function (arquivo) {
    return new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.readAsDataURL(arquivo);
        reader.onload = () => resolve(reader.result);
        reader.onerror = error => reject(error);
    });
};

export const realizarDownload = async function (response, nomearquivo, fileType = "application/pdf") {
    // It is necessary to create a new blob object with mime-type explicitly set
    // otherwise only Chrome works like it should
    var newBlob = new Blob([response.data], {
        type: fileType
    });

    // IE doesn't allow using a blob object directly as link href
    // instead it is necessary to use msSaveOrOpenBlob
    if (window.navigator && window.navigator.msSaveOrOpenBlob) {
        window.navigator.msSaveOrOpenBlob(newBlob);
        return;
    }

    // For other browsers:
    // Create a link pointing to the ObjectURL containing the blob.
    const data = window.URL.createObjectURL(newBlob);
    var link = document.createElement("a");
    link.href = data;
    link.download = nomearquivo;
    link.click();
    setTimeout(function () {
        // For Firefox it is necessary to delay revoking the ObjectURL
        window.URL.revokeObjectURL(data);
    }, 100);
};

export const retornarValorTotalProduto = function (produto)
{
    let valor=  parseFloat(produto.valor)
    let taxaGestao = parseFloat(produto.taxaGestao)
    let ipi = parseFloat(produto.percentualIPI)
    let icms = parseFloat(produto.icms)

    let valorIcms = 0
    if (produto.hasOwnProperty("icms")) {
        valorIcms = parseFloat((valor * icms/100).toFixed(2))
    }
    let valorIpi = parseFloat((valor * ipi/100).toFixed(2))
    
    let valorTotalProduto = (valor + taxaGestao + valorIcms + valorIpi).toFixed(2)

    return valorTotalProduto;
}

export const formatToCurrencyBRL = function (valor) {
    return parseFloat(valor).toLocaleString("pt-BR", {style: "currency", currency: "BRL"})
}

export const paginate = (items, page = 1, perPage = 10) => {
    let offset = perPage * (page - 1);
    let totalPages = Math.ceil(items.length / perPage);
    let paginatedItems = items.slice(offset, perPage * page);

    return {
        previousPage: page - 1 ? page - 1 : null,
        nextPage: (totalPages > page) ? page + 1 : null,
        total: items.length,
        totalPages: totalPages,
        items: paginatedItems
    };
};

export function base64ToArrayBuffer(base64) {
    var binaryString = atob(base64.replace('data:image/png;base64,', ''));
    var bytes = new Uint8Array(binaryString.length);
    for (var i = 0; i < binaryString.length; i++) {
        bytes[i] = binaryString.charCodeAt(i);
    }
    return bytes.buffer;
}