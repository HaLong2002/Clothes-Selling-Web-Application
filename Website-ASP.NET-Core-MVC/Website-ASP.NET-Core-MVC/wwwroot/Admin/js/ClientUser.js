﻿function formatDateForInput(d) {
    const year = d.getFullYear();
    const month = (d.getMonth() + 1).toString().padStart(2, "0");
    const day = d.getDate().toString().padStart(2, "0");
    return `${year}-${month}-${day}`; // Format to yyyy-mm-dd
}

//load dữ liệu lên form sửa
function loadData(id) {
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/Admin/ClientUser/Index',
        success: function (response) {
            console.log("Response from server: ", response);

            const item = response.model;

            $("#matk").val(item.id);
            $("#email").val(item.email);
            $("#fullName").val(item.fullName);
            $("#phoneNumber").val(item.phoneNumber);
            $("#address").val(item.address);
            $("#date").val(formatDateForInput(new Date(item.date)));
            $("#gender").val(item.gender);
            $("#imagePreview").attr("src", item.existingImage);
            $(`#${item.lockoutStatus ? 'blocked' : 'active'}`).prop("checked", true);
        },
        error: function (jqXHR) {
            console.log("Error response:", jqXHR.responseText);
            alert("An error occurred while loading data.");
        }
    });
}

//ajax sửa tài khoản
function suaTaiKhoan() {
    let data = {};
    let formData = $('#update-form').serializeArray();

    // Convert formData into key-value pairs
    $.each(formData, function (index, value) {
        data[value.name] = value.value;
    });

    $.ajax({
        url: '/Admin/ClientUser/Update',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (respone) {
            if (respone.status == true) {
                swal({
                    title: "Thành công!",
                    text: respone.message,
                    type: "success",
                    icon: "success",
                    timer: 1500,
                    button: false
                });
                setTimeout(function () {
                    window.location.replace("/Admin/ClientUser");
                }, 1500)
            } else {
                swal({
                    title: "Thất bại!",
                    text: respone.message,
                    type: "danger",
                    icon: "error",
                    timer: 1500,
                    button: false
                });
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
    $("#delete-user-matk").val(id);
}

function xoaTaiKhoan() {
    let id = $("#delete-user-matk").val();
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/Admin/ClientUser/Delete',
        success: function (response) {
            if (response.status == true) {
                $(".cancelPopup").click();
                $("#row-" + id).remove();
            }
        },
        error: function (response) {
            console.log(xhr.responseText);
            alert("Error has occurred..");
        }
    });
}