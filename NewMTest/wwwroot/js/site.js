var dateFormat = function (data) {
    if (data === "" || data === null) {
        return null;
    }
    return moment(data).format("DD-MM-YYYY");
};

var renderDateDataTable = function (data, type) {
    if (type === "sort" || type === "type") {
        return data;
    }
    return dateFormat(data);
};


$(document).ready(function () {
    $('.table').DataTable({
        oLanguage: {
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisa por Nome ou E-Mail",
            "oPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            },
            "select": {
                "rows": {
                    "_": "Selecionado %d linhas",
                    "0": "Nenhuma linha selecionada",
                    "1": "Selecionado 1 linha"
                }
            },
            "buttons": {
                "copy": "Copiar para a área de transferência",
                "copyTitle": "Cópia bem sucedida",
                "copySuccess": {
                    "1": "Uma linha copiada com sucesso",
                    "_": "%d linhas copiadas com sucesso"
                }
            }
        },
        ordering: true,
        searching: true,
        ajax: {
            url: "/Pessoas/Pesquisa",
            type: "POST",
            data: { sortOrder: "", currentFilter: "", searchString: "", pageNumber: null },
            datatype: "json",
            dataSrc: function (response) {
                response = response;
                return response;
            }
        },
        deferRender: true,
        scrollY: 550,
        scrollX: true,
        scrollCollapse: false,
        scroller: {
            loadingIndicator: true
        },
        columnDefs: [
            { targets: [0, 4], searchable: true },
            { targets: [1, 2, 3, 5, 6, 7], searchable: false }
        ],
        columns: [
            { data: "nome", "name": "Nome" },
            {
                data: "dataNascimento",
                "name": "Data Nascimento",
                "render": function (data, type) { return renderDateDataTable(data, type); }
            },
            { data: "cpf", "name": "CPF" },
            { data: "celular", "name": "Celular" },
            { data: "email", "name": "E-Mail" },
            { data: "endereco", "name": "Endereço" },
            { data: "observacao", "name": "Observação" },
            {
                mRender: function (data, type, row) {
                    var linkEdit = `<a class="btn btn-success" href="/Pessoas/Edit/${row.pessoaId}">Editar</a>`;
                    var linkDetails = `<a class="btn btn-secondary" href="/Pessoas/Details/${row.pessoaId}">Detalhes</a>`;
                    var linkRemove = `<a class="btn btn-danger" href="/Pessoas/Delete/${row.pessoaId}">Delete</a>`;
                    return linkDetails + '|' + linkEdit + '|' + linkRemove;
                }, orderable: false, searchable: false, width: "250px"
            }
        ]
    });
});
