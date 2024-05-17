$(document).ready(function () {
    //let table = new DataTable('#myTable');
    loadDataTable();
});
function loadDataTable() {
    let table = new DataTable('#myTable', {
        "ajax": { "url": '/admin/product/getall' },
        dataSrc: 'data',
        columns: [
            { data: 'title' },
            { data: 'isbn' },
            { data: 'author' },
            { data: 'listPrice' },
            { data: 'category.categoryName' },
            { data: 'extn' }
        ]
    });
};
//function loadDataTable() {
//    let table = new DataTable('#myTable', {
//        "ajax": { "url": '/admin/product/getall' },
//        dataSrc: 'data',
//        columns: [
//            { data: 'id' }
//            { data: 'title' },
//            { data: 'isbn' },
//            { data: 'author' },
//            { data: 'listPrice' },
//            { data: 'category.categoryName' },
            
            
        
            //{
            //    data: 'id',
            //    "render": function (data) {
            //        return `<div class="w-75 btn-group" role="group">
            //            <a href="/admin/product/viewdetails?id=${data}" class="btn btn-secondary mx-1 px-2">
            //                        <i class="bi bi-eye"></i>
            //                    </a>
            //                    <a href="/admin/product/upsert?id=${data}" class="btn btn-secondary mx-1 px-2">
            //                        <i class="bi bi-pencil-square"></i>
            //                    </a>
            //                    <a href="/admin/product/delete?id=${data}" class="btn btn-secondary mx-1 px-2">
            //                        <i class="bi bi-trash"></i>
            //                    </a>
            //        </div>`
            //    },
            //    "width": "25%"
            //}
        ]
    });
    //$('#myTable').DataTable({
    //    "ajax":{ "url": '/admin/product/getall'},
    //    "columns": [
    //        { data: 'title', "width":"25%" },
    //        { data: 'isbn', "width": "15%" },
    //        { data: 'arthor', "width": "10%" },
    //        { data: 'listprice', "width": "15%" },
    //        { data: 'category.name', "width": "10%" },
    //        //{
    //        //    data: 'id',
    //        //    "render": function (data) {
    //        //        return `<div class="w-75 btn-group" role="group">
    //        //            <a href="/admin/product/viewdetails?id=${data}" class="btn btn-secondary mx-1 px-2">
    //        //                        <i class="bi bi-eye"></i>
    //        //                    </a>
    //        //                    <a href="/admin/product/upsert?id=${data}" class="btn btn-secondary mx-1 px-2">
    //        //                        <i class="bi bi-pencil-square"></i>
    //        //                    </a>
    //        //                    <a href="/admin/product/delete?id=${data}" class="btn btn-secondary mx-1 px-2">
    //        //                        <i class="bi bi-trash"></i>
    //        //                    </a>
    //        //        </div>`
    //        //    },
    //        //    "width": "25%"
    //        //}
    //    ]
    //});
};

