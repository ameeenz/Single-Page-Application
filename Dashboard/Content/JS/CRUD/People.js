$(document).ready(function(){
    var autCode=CreateTokken();
    var Element;
    var MyTable=$('#People').DataTable({
       ajax:{
         url:"http://localhost:55769/api/People/",
         dataSrc:"",
         headers:{"Authorization":autCode}
       },
       columns:[
         {data:"Id"},
         {data:"Name"},
         {data:"Family"},
         {data:"Group.Title"},
         {data:"Id",render:function(data)
         {
           return '<button class="js-edit" data-myid="'+data+'">Edit</button> | <button class="js-delete" data-myid="'+data+'">Delete</button>'
         }}
       ]
     });
    $.ajax({
      url:'http://localhost:55769/api/Group/',
      method:'GET',
      headers:{"Authorization":autCode},
      success: function(result){
        var Data='';
        for(var i in result)
        {
          Data+='<option value="'+result[i].Id+'">'+result[i].Title+'</option>';
        }
        $('#Group_Id').html(Data);
      }
    });
   ////////create|update
   $('#btnAdd').click(function(){
     $('#CreateModal').modal('show');
   });
   $('#People').on('click','.js-edit',function(){
     Element=$(this);
     $.ajax({
          url:"http://localhost:55769/api/People/"+Element.attr('data-myid'),
          method:"GET",
          headers:{"Authorization":autCode},
          success: function(result){
           $('#txtId').val(result.Id);
           $('#txtName').val(result.Name);
           $('#txtFamily').val(result.Family);
           $('#Group_Id').val(result.Group_Id);
           $('#CreateModal').modal('show');
          }
     });
   });
   $('#btnCreate').click(function(){
     if($('#txtId').val()=='')
     {
       $.ajax({
       url:'http://localhost:55769/api/People/',
       type:'POST',
       headers:{"Authorization":autCode},
       data:{Name:$('#txtName').val(),Family:$('#txtFamily').val(),Group_Id:parseInt($('#Group_Id').val())},
       success:function(result){
         //MyTable.ajax.reload();
         MyTable.row.add({Id:result.Id,Name:result.Name,Family:result.Family,Group:result.Group}).draw();
         //window.location='index.html';
       },
       error:function()
       {
         alert('we have an error');
       },
       complete:function(){
         $('#txtName').val('');
         $('#txtFamily').val('');
         $('#Group_Id').val('');
         $('#CreateModal').modal('hide');
       }
     });
     }
     else
     {
       $.ajax({
       url:'http://localhost:55769/api/People/',
       type:'PUT',
       headers:{"Authorization":autCode},
       data:{Id:$('#txtId').val(),Name:$('#txtName').val(),Family:$('#txtFamily').val(),Group_Id:parseInt($('#Group_Id').val())},
       success:function(result){
         MyTable.ajax.reload();
       },
       error:function()
       {
         alert('we have an error');
       },
       complete:function(){
         $('#txtId').val('');
         $('#txtName').val('');
         $('#txtFamily').val('');
         $('#Group_Id').val('');
         $('#CreateModal').modal('hide');
       }
     });
     }
   });
   $('#btnClose').click(function(){
         $('#txtId').val(''); 
         $('#txtName').val('');
         $('#txtFamily').val('');
         $('#Group_Id').val('');
         $('#CreateModal').modal('hide');
   });
   ////////create|update
   ////////delete
   $('#People').on('click','.js-delete',function(){
     Element=$(this);
     bootbox.confirm('are you sure you want to delete this item?',function(result){
       if(result)
       {
        $.ajax({
          url:"http://localhost:55769/api/People/"+Element.attr('data-myid'),
          method:"DELETE",
          headers:{"Authorization":autCode},
          success: function(){
            MyTable.row(Element.parents('tr')).remove().draw();
          }
        });
       }
     });
   });
   ////////delete
   });