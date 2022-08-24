var token = ""
function OnClick() {
    fetch("http://localhost:5000/api/Interview", {
        method: "GET",
        headers: {
            "Authorization": "Bearer " + token
        }
    })
        .then(response => response.json())
        .then(interviews => {
            console.log(interviews)
            printInterview(interviews)
        })
}

function Login(name, pass) {
    var body = {
            username: name,
            password: pass
    }
    fetch("http://localhost:5002/api/login", {
        method: "POST",
        headers:{
            "Content-Type": "application/json"
        },
        body : JSON.stringify(body)
        
    })
        .then(response => response.json())
        .then(interviews => token = interviews.token)
}

function printInterview(interviews) {
    var lista = document.getElementById("lista")
    interviews.forEach(i => {
        lista.innerHTML += `<li>${i.name}, ${i.interviewee.firstName}</li>`
    })
}
