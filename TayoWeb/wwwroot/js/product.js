var dataTable = $('#tblTable').DataTable({
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
                return `<div d-flex flex-column flex-sm-row justify-content-center gap-2" role="group">
                        <a href="/admin/product/upsert?id=${data}" class="btn btn-warning btn-sm">
                            <i class="bi bi-pencil-square"></i> Edit
                        </a>
                        <a onClick=Delete('/admin/product/delete/${data}') class="btn btn-danger btn-sm">
                            <i class="bi bi-trash"></i> Delete
                        </a>
                    </div>`;
            },
            orderable: false
        }
    ]
});


function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}