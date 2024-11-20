//Ajax thêm tài khoản
function themTaiKhoanAdmin() {
    let data = {};
    let formData = $('#add-form').serializeArray({
    });
    console.log("Data:", data);

    $.each(formData, function (index, value) {
        data["" + value.name + ""] = value.value;
    });
    //if (data["Password"] != data["ConfirmPassword"]) {
    //    $("#add-message").html("Mật khẩu không khớp");
    //    return false;
    //}
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

            if (!response.success) {
                alert(response.message);
                return;
            }

            const user = response.user;
            const allRoles = response.allRoles.$values;
           
            // Populate the form fields with data from the response
            $("#matk").val(user.id); // Ensure you use the correct path to the user object
            $("#email").val(user.email);
            $("#fullname").val(user.fullName);

            const rolesContainer = $("#roles");
            rolesContainer.empty(); // Clear previous content

            allRoles.forEach(role => {
                const isChecked = user.roles.$values.includes(role); // Check if the user has this role
                const checkboxHtml = `
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" value="${role}" id="${role}-role" ${isChecked ? 'checked' : ''}>
                        <label class="form-check-label" for="${role}-role">${role}</label>
                    </div>
                `;
                rolesContainer.append(checkboxHtml);
            });

            $(`#${user.emailConfirmed ? 'confirmed' : 'notconfirmed'}`).prop("checked", true);
            $(`#${user.lockoutStatus === "Khóa" ? 'blocked' : 'active'}`).prop("checked", true);
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
    let formData = $('#update-form').serializeArray();

    // Convert formData into key-value pairs
    $.each(formData, function (index, value) {
        data[value.name] = value.value;
    });

    data["EmailConfirmed"] = data["EmailConfirmed"] === "true";

    // Collect roles from checkboxes
    let roles = [];
    $("#roles input:checked").each(function () {
        roles.push($(this).val());
    });
    data["Roles"] = roles;

    console.log("Data to submit: ", data);

    $.ajax({
        url: '/Admin/AdminUser/Update',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (response) {
            $("#update-message").html(response.message);

            if (response.status) {
                $("#update-message").addClass("text-success").removeClass("text-danger");
                setTimeout(function () {
                    window.location.replace("/Admin/AdminUser");
                }, 1000);
            } else {
                $("#update-message").addClass("text-danger").removeClass("text-success");
            }
        },
        error: function (response) {
            console.error(response);
            $("#update-message").html("Đã xảy ra lỗi.").addClass("text-danger");
        }
    });

    return false; // Prevent default form submission
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