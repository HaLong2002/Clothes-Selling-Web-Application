function formatDateForInput(d) {
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
            if (item.date != null)
                $("#date").val(formatDateForInput(new Date(item.date)));
            else
                $("#date").val(new Date(item.date));
            $("#gender").val(item.gender);
            $("#imagePreview").attr("src", item.existingImage);
            //$("#imageUpload").val(item.existingImage);
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
    let form = $('#update-form')[0];
    let formData = new FormData(form);

    const lockoutStatus = $("input[name='LockoutStatus']:checked").val() === 'true';  // Convert to boolean (true or false)
    formData.append('LockoutStatus', lockoutStatus);

    $.ajax({
        url: '/Admin/ClientUser/Update',
        type: 'POST',
        data: formData,
        contentType: false, // Important for file upload
        processData: false, // Important for file upload
        success: function (response) {
            if (response.status) {
                swal({
                    title: "Thành công!",
                    text: response.message,
                    icon: "success",
                    timer: 1500,
                    button: false
                });
                setTimeout(function () {
                    window.location.replace("/Admin/ClientUser");
                }, 1500);
            } else {
                swal({
                    title: "Thất bại!",
                    text: response.message,
                    icon: "error",
                    button: "OK"
                });
                //$("#add-message").html(response.message).addClass("text-danger").removeClass("text-success");
            }
        },
        error: function (response) {
            console.error(response);
        }
    });
    return false;
}

function doiEmail() {
    const userId = document.getElementById("matk").value;
    const emailInput = document.getElementById("email"); // Get the input element
    const email = emailInput.value; // Get the input value
    const emailPattern = /^[a-z0-9._%+-]+@gmail\.com$/i;

    if (!emailPattern.test(email)) {
        //alert("Email không hợp lệ!");
        swal({
            title: "Thất bại!",
            text: "Email không hợp lệ!",
            icon: "error",
            button: "OK",
        });
        emailInput.focus(); // Focus on the input element
        return;
    }

    $.ajax({
        url: '/Admin/ClientUser/ChangeEmail',
        type: 'GET',
        data: { id: userId, email: email }, // Send `id` and `email` as query parameters
        success: function (response) {
            if (response.status) {
                swal({
                    title: "Thành công!",
                    text: response.message,
                    icon: "success",
                    button: "OK",
                }).then(function () {
                    window.location.replace("/Admin/ClientUser");
                });
            }
            else {
                swal({
                    title: "Thất bại!",
                    text: response.message,
                    icon: "error",
                    button: "OK",
                })
            }
        },
        error: function (response) {
            swal({
                title: "Lỗi!",
                text: "Có lỗi khi gửi yêu cầu. Vui lòng thử lại.",
                icon: "error",
                button: "OK",
            });
            console.error(response);
        }
    });
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