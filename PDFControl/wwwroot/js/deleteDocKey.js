async function deleteDocKey(id)
{
        if (!confirm("¿Estás seguro de eliminar esta clave?")) return;

    try
    {
        const response = await fetch(`https://localhost:7214/api/Dockeys/${id}`, {
            method: 'DELETE'
        });

        if (response.ok) {
            alert("Clave eliminada correctamente.");
            location.reload(); // Refresca la página para mostrar la lista actualizada
        }
        else {
            alert("Error al eliminar la clave. Intenta de nuevo.");
        }
    }
    catch (error) {
        console.error("Error al eliminar:", error);
        alert("Ocurrió un error al eliminar la clave.");
    }
}

