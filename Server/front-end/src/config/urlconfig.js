const port = "8080";
const protocol = "https";
const base = "virtualresources.sdu.dk";
const creation = "/api/creation";
const management = "/api/management";
const credentials = "/api/my_machines";
const course = "/api/course";
const group = "/api/group";
const educator = "/api/educator";
const groupAssignment = "/api/groupassignment";
const machine = "/api/machine";
const login = "/api/login";

function getBase (){
    return window.location.host
}

function loginTokenReturnString (){
    return encodeURIComponent(protocol + "://"+getBase() + "/Login");
}


export default {
    getBase,
    port,
    protocol,
    base,
    creation,
    management,
    educator,
    credentials,
    login,
    loginTokenReturnString,
    course,
    group,
    groupAssignment,
    machine,
};
