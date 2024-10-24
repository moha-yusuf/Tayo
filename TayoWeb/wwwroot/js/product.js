$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblTable').DataTable({
        "ajax": { url: '/admin/product/GetAll' },
        "columns": [
            { data: 'name' },
            { data: 'price' },
            { data: 'collection.name' },
            { data: 'category.name' },
            { data: 'productSize.name' },
            { data: 'isAvailable' },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/product/upsert?id=${data}" class="btn btn-warning btn-sm"><i class="bi bi-pencil-square"></i> Edit</a>
                     <a class="btn btn-danger btn-sm"><i class="bi bi-trash"></i> Delete</a>
                    </div>`
                },
                "width": "25%"
            }
        ],

        // Use Bootstrap styling for pagination and length menu
        "dom": '<"row"<"col-md-6"l><"col-md-6 d-flex justify-content-end"f>>' +
            'rt' +
            '<"row"<"col-md-6"i><"col-md-6 d-flex justify-content-end"p>>',
        "pagingType": "full_numbers",  // Optional: You can use 'simple', 'simple_numbers', etc. if preferred
        "language": {
            "lengthMenu": "Show _MENU_ entries",
            "zeroRecords": "No matching products found",
            "info": "Showing _START_ to _END_ of _TOTAL_ entries",
            "infoEmpty": "No entries available",
            "infoFiltered": "(filtered from _MAX_ total entries)",
            "paginate": {
                "first": "<<",
                "last": ">>",
                "next": "»",
                "previous": "«"
            }
        }
    });
}

