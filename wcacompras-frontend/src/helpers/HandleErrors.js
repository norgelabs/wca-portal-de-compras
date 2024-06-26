import { useAuthStore } from "@/store/auth.store";
import router from "@/router"
const handleErrors = (error, customMessage = null) =>
{
    let authStore = useAuthStore();
    let swal = require("sweetalert2")
    let message = ""
    let messageType = "error";
    if (customMessage) {
        message = customMessage;
    }else if (error.response) {
        message = error.response.status + ", " + (error.response.data.message || error.response.data.title);
        if (error.response.status === 404) {
            message = "O registro não foi localizado!";
            if (typeof(error.response.data) != 'object' && error.response.data.trim() != '')
                message =error.response.data;
            messageType = "info";
        } else if (error.response.status === 403) {
            
        } else if (error.response.status === 401) {
            authStore.finishSession();
            router.push({ name: "login" })
            return
        } else if (error.response.status === 500) {
            if (error.response.data.indexOf("System.Exception:") > -1)
                message = error.response.data.toString().split("\r\n")[0].replace("System.Exception: ", "")
                    .replace("System.Exception: ","");
        } else if (message.indexOf("Cannot delete or update a parent row") > -1) {
            message = "Este dado esta relacionado à outro(s) cadastro(s) e não pode ser excluído!";
        }
    } else if (error.request)
    {
        if (error.request.status == 401)
        {
            authStore.finishSession();
            router.push({name: "login"})
            return
        }
        message = `${error.request.status} - Houve um erro na sua requisição!`
        if (error.request.message && error.request.message != "")  {
            message = `${error.request.status} - ${error.request.message}!`
        }
        
    } else {
        message = error.message
    }
    swal.fire({
      toast: true,
      icon: messageType,
      position: "top-end",
      title: "Ops! Algo deu errado",
      text: message,
      showConfirmButton: false,
      timer: 2000,
    })
    
}

export default handleErrors;
