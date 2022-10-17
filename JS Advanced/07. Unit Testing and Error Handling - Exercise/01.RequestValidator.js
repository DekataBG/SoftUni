function requestValidator(request) {
    let { method, uri, version, message} = request;

    if(!['GET', 'POST', 'DELETE', 'CONNECT'].includes(method) || typeof method == 'undefined') {
        throw new Error("Invalid request header: Invalid Method");
    }

    if(/^(\.*[a-zA-Z]*[0-9]*\.*\**)+$/g.test(uri) == false || uri == '' || typeof uri == 'undefined') {
        throw new Error("Invalid request header: Invalid URI");
    }

    if(!['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'].includes(version) || typeof version == 'undefined') {
        throw new Error("Invalid request header: Invalid Version");
    }

    if(/^[^<>\\&'"]*$/g.test(message) == false || typeof message == 'undefined') {
        throw new Error("Invalid request header: Invalid Message");
    }

    return request;
}


console.log(requestValidator({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
}));

