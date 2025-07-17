document.getElementById("uploadForm").addEventListener("submit", async function (event) {
    event.preventDefault();

    const fileInput = document.getElementById("pdfFile");
    const file = fileInput.files[0];
    const resultDiv = document.getElementById("result");

    if (!file || file.type !== "application/pdf") {
        resultDiv.innerHTML = `<div class="alert alert-danger">Por favor verifique el archivo PDF.</div>`;
        return;
    }
    const formData = new FormData();
    formData.append("file", file);
    try {
        const response = await fetch("https://localhost:7214/api/Upload", {
            method: "POST",
            body: formData
        });
        const result = await response.json();
        if (response.ok) {
            resultDiv.innerHTML = `<div class="alert alert-success">Archivo subido exitosamente.</div>`;
        }
        else {
            resultDiv.innerHTML = `<div class="alert alert-danger">Error al subir el archivo: ${result.message}</div>`;
        }
    }
    catch (error) {
        resultDiv.innerHTML = `<div class="alert alert-danger">Error al subir el archivo. Por favor, intente de nuevo.</div>` + error;
    }

}
);