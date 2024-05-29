const UrlAllUsers = "http://localhost:5016/ApiUdes/User";
const UrlAllRoles = "http://localhost:5016/ApiUdes/Rol";
const UrlAllUserRoles = "http://localhost:5016/ApiUdes/Userrole/GetUserRolList";
const UrlUserByName = "http://localhost:5016/ApiUdes/User/GetUserByName";
const UrlAddUser = "http://localhost:5016/ApiUdes/User";
const ExpReguNormal = /^[a-zA-Z0-9]+$/;
const ExpReguEmail = /^[a-zA-Z0-9._@-]+$/;

const CheckData = (data, expRegu) => {
  return expRegu.test(data);
};

const AddData = async (url, data) => {
  let dataResp = await fetch(url, data);
  let dataJson = await dataResp.json();
  return await dataJson;
};

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

const ChanMainCont = async (titlePage, tHeaders, tContent) => {
  let mainTitle = document.querySelector("#mainTitle");
  let tableTitle = document.querySelector("#tableTitle");
  let mainTable = document.querySelector("#mainTable");
  mainTitle.innerHTML = titlePage;
  tableTitle.innerHTML = titlePage;
  mainTable.innerHTML = "";

  mainTable.insertAdjacentHTML(
    "beforeend",
    /* html */ `
                <thead>
                <tr>
                   ${tHeaders.map((h) => `<th> ${h} </th>`).join("")} 
                   <th> Actions </th>    
                </tr>
                </thead>
                <tbody>
                ${tContent
                  .map(
                    (r) => `
                      <tr>
                        ${Object.entries(r)
                          .map(
                            (k, v) => `
                            <td>${k[1]}</td>
                        `
                          )
                          .join("")}
                        <td> 
                          <a id="btnEdit" href="#" class="btnFuntion" ><i class="fa-solid fa-pen-to-square"></i></a>
                          <a id="btnDelete" href="#" class="btnFuntion" ><i class="fa-solid fa-trash-can"></i></a>
                        </td>
                      </tr>
                    `
                  )
                  .join("")}
                
                </tbody>
    `
  );
};

export {
  UrlAllUsers,
  UrlUserByName,
  UrlAllRoles,
  UrlAllUserRoles,
  ExpReguNormal,
  ExpReguEmail,
  UrlAddUser,
  CheckData,
  GetData,
  AddData,
  GetDataWithConfig,
  ChanMainCont
};
