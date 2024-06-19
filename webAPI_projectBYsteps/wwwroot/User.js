const Login = async () => {
    const LoginUser = {
        Email: document.getElementById("email").value,
        Password: document.getElementById("password").value
    }
    const res = await fetch('api/user/login', {
        method: 'POST',
        headers: {
            'content-Type': 'application/json'
        },
        body: JSON.stringify(LoginUser)
    });
    //if (!res.ok) {
    //    alert("Unauthorized:(")
    //    throw new Error(`Unauthorized ${res.status}`)
    //}
    //else {
    //    alert("you're succesfully logged in")
    //    window.location.href="Products.html"
    //}
    if (!res.ok) {
        alert("Unauthorized:(")
        throw new Error(`Unauthorized ${res.status}`)
    }
    else {
        alert("you're succesfully logged in")

        //sessionStorage.setItem("id", response.json.UserId);
        sessionStorage.setItem("user", JSON.stringify(LoginUser));
        window.location.href = "Products.html"
    }
};

const Register = async () => {
    const RegisterUser = {
        Email: document.getElementById("email").value,
        Password: document.getElementById("password").value,
        FirstName: document.getElementById("firstName").value,
        LastName: document.getElementById("lastName").value,
        UserId: 0

    }
    const res = await fetch('api/user', {
        method: 'POST',
        headers: {
            'content-Type': 'application/json'
        },
        body: JSON.stringify(RegisterUser)
    });
    if (!res.ok) {
        alert("Unauthorized:(")
        throw new Error(`Unauthorized ${res.status}`)
    }
    else {
        alert("you're succesfully logged in")
        /*  window.location.href = "Products.html"*/
    }
};
   
const Update = async () => {

    const UpdatedUser = {
        Email: document.getElementById("email").value,
        Password: document.getElementById("password").value,
        FirstName: document.getElementById("firstName").value,
        LastName: document.getElementById("lastName").value,
        UserId: document.getElementById("UserId").value,
    }
    const res = await fetch(`api/user/${UpdatedUser.UserId}`, {
        method: 'PUT',
        headers: {
            'content-Type': 'application/json'
        },
        body: JSON.stringify(UpdatedUser)
    });
    if (!res.ok) {
        alert("failed to update")
        throw new Error(`failed to update ${res.status}`)
    }
    else {
        alert("update is done")
        window.location.href = "Login.html"
    }
};