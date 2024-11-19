//Ajax thêm tài khoản
function themTaiKhoanAdmin() {
    let data = {};
    let formData = $('#add-form').serializeArray({
    });
    console.log("Data:", data);

    $.each(formData, function (index, value) {
        data["" + value.name + ""] = value.value;
    });
    if (data["Password"] != data["ConfirmPassword"]) {
        $("#add-message").html("Mật khẩu không khớp");
        return false;
    }
    $.ajax({
        url: '/Admin/AdminUser/Create',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (respone) {
            $("#add-message").html(respone.message);
            if (respone.status == true) {
                $("#add-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Admin/AdminUser");
                }, 1000)
            } else {
                $("#add-message").addClass("text-danger");
            }
        },
        error: function (jqXHR) {
            console.log("Error response:", jqXHR.responseText);
            alert("An error occurred.");
        }
    });
    return false;
}

//load dữ liệu lên form sửa
function loadData(id) {
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/Admin/AdminUser/Index',
        success: function (response) {
            console.log("Response from server:", response);

            let item = response.taikhoansWithLockoutStatus.$values[0]; 
           
            // Populate the form fields with data from the response
            $("#matk").val(item.id); // Ensure you use the correct path to the user object
            $("#email").val(item.email);
            $("#fullname").val(item.fullName);

            // Set the radio buttons for account type
            if (item.loaiTaiKhoan === true) {
                $("#admin-role").prop("checked", true);
            } else {
                $("#manager-role").prop("checked", true);
            }

            if (item.emailConfirmed === true) {
                $("#confirmed").prop("checked", true);
            } else {
                $("#notconfirmed").prop("checked", true);
            }

            if (item.lockoutStatus === 'Khóa') {
                $("#blocked").prop("checked", true);
            } else {
                $("#active").prop("checked", true);
            }
        },
        error: function (jqXHR) {
            console.log("Error response:", jqXHR.responseText);
            alert("An error occurred while loading data.");
        }
    });
}


//ajax sửa tài khoản quản trị
function suaTaiKhoanQuanTri() {
    let data = {};
    let formData = $('#update-form').serializeArray({
    });
    $.each(formData, function (index, value) {
        data["" + value.name + ""] = value.value;
    });

    if (data["EmailConfirmed"]) {
        data["EmailConfirmed"] = data["EmailConfirmed"] === "true";
    }

    console.log("Data: ", data);

    $.ajax({
        url: '/Admin/AdminUser/Update',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (respone) {

            $("#update-message").html(respone.message);

            if (respone.status == true) {
                $("#update-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Admin/AdminUser");
                }, 1000)
            } else {
                $("#update-message").addClass("text-danger");
            }
        },
        error: function (respone) {
            console.log(respone);
        }
    });
    return false;
}

//load data lên form xóa
function deleteData(id) {
    $("#delete-message").html("");
    $("#delete-adminuser-id").val(id);
}

function xoaTaiKhoan() {
    let id = $("#delete-adminuser-id").val();
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/Admin/AdminUser/Delete',
        success: function (response) {
            if (response.status == true) {
                $(".cancelPopup").click();
                $("#row-" + id).remove();
            } else {
                $("#delete-message").html(response.message);
            }
        },
        error: function (response) {
            console.log(xhr.responseText);
            alert("Error has occurred..");
        }
    });  
}