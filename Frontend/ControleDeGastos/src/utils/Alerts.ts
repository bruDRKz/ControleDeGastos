import Swal from "sweetalert2"

export function sucesso(mensagem: string) {
    Swal.fire({
        icon: "success",
        title: "Sucesso",
        text: mensagem,
        confirmButtonColor: "#4f46e5"
    })
}

export function erro(mensagem: string) {
    Swal.fire({
        icon: "error",
        title: "Erro",
        text: mensagem,
        confirmButtonColor: "#ef4444"
    })
}

export function aviso(mensagem: string) {
    Swal.fire({
        icon: "warning",
        title: "Atenção",
        text: mensagem,
        confirmButtonColor: "#f59e0b"
    })
}

export async function confirmacao(mensagem: string): Promise<boolean> {

    const resultado = await Swal.fire({
        icon: "question",
        title: "Confirmar",
        text: mensagem,
        showCancelButton: true,
        confirmButtonText: "Sim",
        cancelButtonText: "Cancelar",
        confirmButtonColor: "#4f46e5"
    });

    return resultado.isConfirmed;
}