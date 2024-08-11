import axios from "axios";

const apiUrl = "https://localhost:7287/api/"
export const getAllEvents = async (name, category, location) => {
    try {
        const payload = {
            name: name || '',
            category: category || '',
            location: location || ''
        };
        var response = await axios.post(apiUrl + 'Event/GetEvents',
            payload,
            {
                headers: {
                    'Content-Type': 'application/json'
                }
            })
        console.log("response: ", response)
        return response;
    } catch (err) {
        console.log("err: ", err)
        return false;
    }
}