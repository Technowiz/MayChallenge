import axios from "axios";
const baseUrl="https://localhost:44339/api/"

export default {
    schedule(url= baseUrl+'Schedules/'){
        return {
            fetchAll :()=>axios.get(url),
            fetchById:id=>axios.get(url+id),
            create: newRecord => axios.post(url.newRecord),
            update:(id,updateRecord)=>axios.put(url+id,updateRecord),
            delete:id =>axios.delete(url+id)
        }
    }
}

export const insertRecurrence = (recurrence) => {
    axios.post(baseUrl + 'Schedules', recurrence)
    .then((response) => console.log(response))
}

export const deleteRecurrence = (id) => {
    axios.delete(baseUrl + 'Schedules/'+ id)
    .then((response) => console.log(response))
}


export const fetchALL = () => {
    let recurences = axios.get(baseUrl + 'Schedules').then()
    console.log(recurences)
    return recurences
}
