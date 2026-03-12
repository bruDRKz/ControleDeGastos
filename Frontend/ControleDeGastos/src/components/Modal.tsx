import { useEffect } from "react";
import type { ReactNode } from "react";

type ModalProps = {
    aberto: boolean
    fechar: () => void
    children: ReactNode
}

function Modal({ aberto, fechar, children }: ModalProps) {

    useEffect(() => {

        function handleEsc(event: KeyboardEvent) {
            if (event.key === "Escape") {
                fechar();
            }
        }

        if (aberto) {
            window.addEventListener("keydown", handleEsc);
        }

        return () => {
            window.removeEventListener("keydown", handleEsc);
        };

    }, [aberto, fechar]);

    if (!aberto) return null;

    return (
        <div
            className="fixed inset-0 bg-black/30 backdrop-blur-sm flex items-center justify-center z-50"
            onClick={fechar} // Fecha ao clicar fora
        >

            <div
                className="bg-white p-6 rounded-xl w-full max-w-md shadow-2xl border border-gray-100 animate-[fadeIn_0.2s_ease-out]"
                onClick={(e) => e.stopPropagation()} // O stop é pra não ativar o gatilho de cima quando clicar dentro da div do modal
            >

                {children}

                <div className="flex justify-end mt-6">
                    <button
                        onClick={fechar}
                        className="text-gray-600 hover:text-gray-800"
                    >
                        Fechar
                    </button>
                </div>

            </div>

        </div>
    );
}

export default Modal;