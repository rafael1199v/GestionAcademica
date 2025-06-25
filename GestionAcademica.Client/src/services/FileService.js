import { axiosInstance } from "./AxiosInstance";

class FileService {
    constructor() {
        this.http = axiosInstance;
    }


    async downloadFile(id, name, extension) {
        try {
            const response = await this.http.get(`/File/${id}`, {
                responseType: "blob"
            });
            
            const blob = new Blob([response.data]);
            
            const url = window.URL.createObjectURL(blob);
            const link = document.createElement("a");

            link.href = url;
            link.download = `${name}${extension}`;
            link.click();
            link.remove();

            URL.revokeObjectURL(url);

        }
        catch(error) {
            console.log(error);
            alert("No se pudo descargar el archivo");
            throw new Error("No se pudo descargar el archivo");
        }
    }


}

const fileService = new FileService();
export default fileService;