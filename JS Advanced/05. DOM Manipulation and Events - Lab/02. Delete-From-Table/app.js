function deleteByEmail() {
    let emails = Array
        .from(document.querySelectorAll("tbody>tr>td:nth-of-type(2n)"))
        .map(x => x.textContent);

    let input = document.getElementsByName("email")[0].value;
    let result = document.getElementById("result");

    if(emails.includes(input)) {
        result.textContent = "Deleted.";

        let row = Array
            .from(document.querySelectorAll("tbody>tr"))
            .find(x => x.textContent.includes(input));

        row.remove();
    } else {
        result.textContent = "Not found." ;
    }
}