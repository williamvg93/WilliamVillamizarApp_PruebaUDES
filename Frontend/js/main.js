console.log("Connected ....");
const UrlAllUsers = "http://localhost:5016/ApiUdes/User";
const UrlUserByName = "http://localhost:5016/ApiUdes/User/GetUserByName";

let btnLogin = document.querySelector("#btn_login");
let userName = document.querySelector("#user_name");
let userPass = document.querySelector("#user_pass");
console.log(btnLogin);

const GetData = async (url) => {
  let data = await fetch(url);
  let dataJson = await data.json();
  return await dataJson;
};

const GetDataWithConfig = async (url, config) => {
  let data = await fetch(url, config);
  /* console.log(await data.text()); */
  let dataJson = await data.json();
  return await dataJson;
};

const CreateAlert = (title, text, icon, btnConfir) => {
  Swal.fire({
    title: title,
    text: text,
    icon: icon,
    confirmButtonText: btnConfir
  });
};

btnLogin.addEventListener("click", (e) => {
  e.preventDefault();
  console.log("Click !!!!");
  /*   console.log(userName.value);
  console.log(userPass.value); */

  let checkUser = {
    user1: userName.value,
    password: userPass.value
  };

  let confApi = {
    method: "POST",
    headers: { "content-Type": "application/json" },
    body: JSON.stringify(checkUser)
  };

  /* let getAllUsers = GetData(UrlUserByName).then(data => {
    console.log(data)
  }); */
  let checkUserExis = GetDataWithConfig(UrlUserByName, confApi).then((data) => {
    console.log(data);
    if (!data.user1) {
      /* alert (data.resp) */
      CreateAlert(
        "Usuario No encontrado!",
        data.resp,
        "warning",
        "Confirmar",
        "false"
      );
    } else {
      /*       CreateAlert(
        `Bienvenido ${data.user1}!`,
        "Inicio de sesion Exitoso !!",
        "success",
        "Aceptar",
        window.location.replace("./layouts/dashboard.html")
      ); */
      Swal.fire({
        title: `Bienvenido ${data.user1}!`,
        text: "Inicio de sesion Exitoso !!",
        icon: "success",
        confirmButtonText: "Aceptar"
      }).then((resp) => {
        if (resp.value) {
          window.location.replace("./layouts/dashboard.html");
        }
      });
    }
  });
});
