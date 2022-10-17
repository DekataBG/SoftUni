function validate() {
  let button = document.getElementById("submit");
  let username = document.getElementById("username");
  let email = document.getElementById("email");
  let password = document.getElementById("password");
  let confirmPassword = document.getElementById("confirm-password");
  let companyInfo = document.getElementById("companyInfo");
  let company = document.getElementById("company");
  let companyNumber = document.getElementById("companyNumber");
  let validDiv = document.getElementById("valid");

  company.addEventListener("change", (e) => {
    companyInfo.style.display = e.target.checked ? "block" : "none";
  });

  button.addEventListener("click", onclick);

  function onclick(e) {
    let valid = true;

    e.preventDefault();

    //username
    if (
      username.value.length < 3 ||
      username.value.length > 20 ||
      !/^[a-zA-Z0-9]*$/g.test(username.value)
    ) {
      username.style = "border-color: red";
      valid = false;
    } else {
      username.style = "border-color: none";
      valid = valid && true;
    }

    //confirmPassword
    if (
      password.value != confirmPassword.value ||
      confirmPassword.value.length < 5 ||
      confirmPassword.value.length > 15 ||
      !/^\w+$/g.test(confirmPassword.value)
    ) {
      confirmPassword.style = "border-color: red";
      valid = false;
    } else {
      confirmPassword.style = "border-color: none";
      valid = valid && true;
    }

    //password
    if (
      password.value != confirmPassword.value ||
      password.value.length < 5 ||
      password.value.length > 15 ||
      !/^\w+$/g.test(password.value)
    ) {
      password.style = "border-color: red";
      valid = false;
    } else {
      password.style = "border-color: none";
      valid = valid && true;
    }

    //email
    if (!/^.*@.*\..*$/g.test(email.value)) {
      email.style = "border-color: red";
      valid = false;
    } else {
      email.style = "border-color: none";
      valid = valid && true;
    }

    //company number
    if (company.checked) {
      if (companyNumber.value < 1000 || companyNumber.value > 9999) {
        companyNumber.style = "border-color: red";
        valid = false;
      } else {
        companyNumber.style = "border-color: none";
        valid = valid && true;
      }
    }

    validDiv.style = valid ? "display: block" : "display: none";
  }
}
