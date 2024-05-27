console.log("Connected ....");
const UrlUsers = "http://localhost:5016/ApiUdes/User"

let btnLogin = document.querySelector("#btn_login");
let userName = document.querySelector("#user_name");
let userPass = document.querySelector("#user_pass");
console.log(btnLogin)

const GetData = async (url) => {
  let data = await fetch(url)
  let dataJson = await data.json();
  return await dataJson
}


btnLogin.addEventListener("click", (e) => {
  e.preventDefault();
  console.log("Click !!!!")
  console.log(userName.value)
  console.log(userPass.value)
  let getAllUsers = GetData(UrlUsers).then(data => {
    console.log(data)
  });
})

