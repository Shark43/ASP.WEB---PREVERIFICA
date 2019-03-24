$(document).ready(function () {
    const endpoint = `http://localhost:58241/api`;
    const txtArea = $("#txtArea");
    const txtID = $("#txtID");
    $("#btnGetALL").on("click", () => {
        const ir = inviaRichiesta(`${endpoint}/studenti`, 'GET', {});
        ir.done((data, textStatus, jqHXR) => {
            txtArea.text(JSON.stringify(data, undefined, 2));
        });
        ir.fail((jqXHR, textStatus, errorThrown) => {
            console.log(jqXHR, textStatus, errorThrown);
        });

    });

    $("#btnGetOne").on("click", () => {

        const ir = inviaRichiesta(`${endpoint}/studenti/${txtID.val()}`, 'GET', {});
        ir.done((data, textStatus, jqHXR) => {
            txtArea.text(JSON.stringify(data, undefined, 2));
        });
        ir.fail((jqXHR, textStatus, errorThrown) => {
            console.log(jqXHR, textStatus, errorThrown);
        });

    });

    $("#btnDeleteOne").on("click", () => {

        const ir = inviaRichiesta(`${endpoint}/studenti/${txtID.val()}`, 'DELETE', {});
        ir.done((data, textStatus, jqHXR) => {
            txtArea.text(JSON.stringify(data, undefined, 2));
        });
        ir.fail((jqXHR, textStatus, errorThrown) => {
            console.log(jqXHR, textStatus, errorThrown);
        });

    });

    $("#btnUpdateOne").on("click", () => {

        const ir = inviaRichiesta(`${endpoint}/studenti`, 'PUT', {
            ID: txtID.val(),
            Nome: "Up",
            Cognome: "Down",
            Anni: 99
        });
        ir.done((data, textStatus, jqHXR) => {
            txtArea.text(JSON.stringify(data, undefined, 2));
        });
        ir.fail((jqXHR, textStatus, errorThrown) => {
            console.log(jqXHR, textStatus, errorThrown);
        });

    });

    $("#btnInsertOne").on("click", () => {

        const ir = inviaRichiesta(`${endpoint}/studenti`, 'POST', {
            Nome: "Ins",
            Cognome: "Del",
            Anni: 98
        });
        ir.done((data, textStatus, jqHXR) => {
            txtArea.text(JSON.stringify(data, undefined, 2));
        });
        ir.fail((jqXHR, textStatus, errorThrown) => {
            console.log(jqXHR, textStatus, errorThrown);
        });

    });
    const inviaRichiesta = (_url, method, params) => {
        return $.ajax({

            type: method,

            url: _url,

            dataType: 'json',

            contentType: 'application/json;charset= UTF-8',

            data: JSON.stringify(params),

            timeout: 12000,

            crossDomain: true,
        });
    }
});

