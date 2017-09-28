$(function () {
    $("#jqGrid").jqGrid({
        url: "/Customers/GetCustomers",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['CustomerId', 'CustomerName', 'Address', 'MobileNo','City','State'],
        colModel: [
            { key: true, hidden: true, name: 'CustomerId', index: 'CustomerId', editable: true },
            { key: false, name: 'CustomerName', index: 'CustomerName', editable: true },
            { key: false, name: 'Address', index: 'Address', editable: true },
            { key: false, name: 'MobileNo', index: 'MobileNo', editable: true },
           
            { key: false, name: 'City', index: 'City', editable: true },
           
            { key: false, name: 'State', index: 'State', editable: true }],
            pager: jQuery('#jqControls'),
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        height: '100%',
        viewrecords: true,
        caption: 'Customers Records',
        emptyrecords: 'No Customers Records are Available to Display',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: false
    }).navGrid('#jqControls', { edit: true, add: true, del: true, search: false, refresh: true },
        {
            zIndex: 100,
            url: '/Customers/Edit',
            closeOnEscape: true,
            closeAfterEdit: true,
            recreateForm: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            url: "/Customers/Create",
            closeOnEscape: true,
            closeAfterAdd: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            url: "/Customers/Delete",
            closeOnEscape: true,
            closeAfterDelete: true,
            recreateForm: true,
            msg: "Are you sure you want to delete Customer... ? ",
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        });
});