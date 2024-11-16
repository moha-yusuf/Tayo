$('#tblTable').DataTable({
    "order": [], // Disable initial sorting
    "ajax": { url: '/admin/product/GetAll' },
    "columns": [
        { data: 'name', orderable: true },
        { data: 'price', orderable: true },
        { data: 'collection.name', orderable: true },
        { data: 'category.name', orderable: true },
        { data: 'productSize.name', orderable: true },
        { data: 'isAvailable', orderable: true },
        {
            data: 'id',
            render: function (data) {
                return `<div class="w-75 btn-group" role="group">
                        <a href="/admin/product/upsert?id=${data}" class="btn btn-warning btn-sm">
                            <i class="bi bi-pencil-square"></i> Edit
                        </a>
                        <a class="btn btn-danger btn-sm">
                            <i class="bi bi-trash"></i> Delete
                        </a>
                    </div>`;
            },
            orderable: false
        }
    ]
});
