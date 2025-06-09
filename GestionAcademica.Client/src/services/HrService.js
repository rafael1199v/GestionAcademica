class HrService {

    async getApplications () {
        return [{
            id: 1,
            applicantName: "Rafael",
            subjectName: "Arquitectura de software",
            subjectId: 1,
            applicantId: 1,
        }, {
            id: 2,
            applicantName: "Andres",
            subjectName: "Introduccion a programcion",
            subjectId: 2,
            applicantId: 2
        }];
    }


    async getById(id) {
        return {
            id: id,
            applicantName: "Rafael",
            subjectName: "Introduccion a programacion",
            careerName: "Ingenieria de software",
            administratorName: "Jose Jesus Cabrera",
            files: [
                {
                    id: 1,
                    name: "Curriculum",
                    extension: ".docx"
                },
                {
                    id: 2,
                    name: "Certificacion AWS",
                    extension: ".pdf"
                }
            ],
            subjectId: 2,
            applicantId: 2
        };
    }
}


const hrService = new HrService();
export default hrService;