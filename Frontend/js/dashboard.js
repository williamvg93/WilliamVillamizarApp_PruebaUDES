import {
  AddData,
  ChanMainCont,
  CheckData,
  ExpReguEmail,
  ExpReguNormal,
  GetData,
  GetDataWithConfig,
  UrlAddUser,
  UrlAllRoles,
  UrlAllUserRoles,
  UrlAllUsers,
  UrlUserByName
} from "../js/funtions.js";

let btnUsers = document.querySelector("#btnUsers");
let btnRoles = document.querySelector("#btnRoles");
let btnUserRoles = document.querySelector("#btnUserRoles");
let btnAdd = document.querySelector("#btnAdd");

window.addEventListener("load", function () {
  console.log("La página ha terminado de cargarse!!");
  let getAllUsers = GetData(UrlAllUsers).then((data) => {
    console.log(data);
    console.log(Object.keys(data[0]));
    let tableHeaders = Object.keys(data[0]);
    ChanMainCont("Users", tableHeaders, data);
  });
});

btnUsers.addEventListener("click", (e) => {
  e.preventDefault();
  console.log("Hola!");
  let getAllUsers = GetData(UrlAllUsers).then((data) => {
    let tableHeaders = Object.keys(data[0]);
    ChanMainCont("Users", tableHeaders, data);
  });
});

btnRoles.addEventListener("click", (e) => {
  e.preventDefault();
  console.log("Roles!");
  let getAllRoles = GetData(UrlAllRoles).then((data) => {
    let tableHeaders = Object.keys(data[0]);
    ChanMainCont("Roles", tableHeaders, data);
  });
});

btnUserRoles.addEventListener("click", (e) => {
  e.preventDefault();
  console.log("UserRoles!");
  let getAllUserRoles = GetData(UrlAllUserRoles).then((data) => {
    let tableHeaders = Object.keys(data[0]);
    ChanMainCont("UserRoles", tableHeaders, data);
  });
});

btnAdd.addEventListener("click", (e) => {
  e.preventDefault();
  Swal.fire({
    title: `Bienvenido!`,
    icon: "success",
    html:
      '<input class="swal2-input" id="impName" placeholder = "Name">' +
      '<input class="swal2-input" id="impLastName" placeholder = "LastName">' +
      '<input class="swal2-input" id="impDocType" placeholder = "Document Type">' +
      '<input class="swal2-input" id="impIdenNum" placeholder = "Document Number">' +
      '<input class="swal2-input" id="impEmail" placeholder = "Email">' +
      '<input class="swal2-input" id="impUser1" placeholder = "User">' +
      '<input class="swal2-input" id="impPassword" placeholder = "Password">',
    confirmButtonText: "Crear"
  }).then((resp) => {
    if (resp.value) {
      let impName = document.querySelector("#impName").value.trim();
      let impLastName = document.querySelector("#impLastName").value.trim();
      let impDocType = document.querySelector("#impDocType").value.trim();
      let impIdenNum = document.querySelector("#impIdenNum").value.trim();
      let impEmail = document.querySelector("#impEmail").value.trim();
      let impUser1 = document.querySelector("#impUser1").value.trim();
      let impPassword = document.querySelector("#impPassword").value.trim();

      if (
        CheckData(impName, ExpReguNormal) &&
        CheckData(impLastName, ExpReguNormal) &&
        CheckData(impDocType, ExpReguNormal) &&
        CheckData(impIdenNum, ExpReguNormal) &&
        CheckData(impEmail, ExpReguEmail) &&
        CheckData(impUser1, ExpReguNormal) &&
        CheckData(impPassword, ExpReguNormal)
      ) {
        let newUser = {
          name: impName,
          lastName: impLastName,
          docType: impDocType,
          idenNum: impIdenNum,
          email: impEmail,
          user1: impUser1,
          password: impPassword
        };
        console.log(newUser);

        let confApi = {
          method: "POST",
          headers: { "content-Type": "application/json" },
          body: JSON.stringify(newUser)
        };

        let addNewUser = AddData(UrlAddUser, confApi).then((resp) => {
          console.log(resp);
        });
        location.reload();
      } else {
        Swal.fire({
          title: "Error",
          text: "Complete all data for continue..",
          icon: "warning",
          confirmButtonText: "Close"
        });
      }
    }
  });
});
