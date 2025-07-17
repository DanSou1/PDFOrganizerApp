const form = document.getElementById("docKeyForm");

form.onsubmit = async function (e) {
    e.preventDefault();

    const docName = document.getElementById("docName").value;
    const keyStone = document.getElementById("keyStone").value;

    const data = {
        docName: docName,
        keyStone: keyStone
    };

    const url = "https://localhost:7214/api/Dockeys";

    try {
        const response = await fetch(url, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(data)
        });

        if (response.ok) {
            alert("Clave guardada correctamente.");
            location.reload();
        } else {
            alert("Error al guardar la clave.");
        }
    } catch (error) {
        console.error("Error en la solicitud:", error);
        alert("Error inesperado.");
    }
};
