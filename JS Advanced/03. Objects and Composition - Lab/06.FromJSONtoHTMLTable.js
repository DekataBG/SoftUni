function fromJSONToHTMLTable(input){
    input = JSON.parse(input);

    let properties = [];
    for(let prop in input[0]){
        properties.push(prop);
    }

    let output = '<table>';
    
    output += '\n\t<tr>';

    for(let prop in input[0]){
        output += `<th>${escapeHtml(prop)}</th>`;
    }
    output += '</tr>'
    
    for(object of input){
        output += '\n\t<tr>'
        for(let prop in object){
            output += `<td>${escapeHtml(object[prop])}</td>`;
        }
        output += '</tr>';
    }

    
    output += '\n</table>';

    console.log(output);

    function escapeHtml(value) {
        return value
            .toString()
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }
}

fromJSONToHTMLTable(
`[{"Name":"Pesho","Score":4,"Grade":"8"},{"Name":"Gosho","Score":5,"Grade":"8"},{"Name":"Angel","Score":5.5,"Grade":"10"}]`);