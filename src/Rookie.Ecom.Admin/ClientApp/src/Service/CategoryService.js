import axios from "axios"
export const getListcate = async()=>{
    const res = await axios.get("https://localhost:5011/api/Category")
    return res.data
}

export const add = async(props)=>{
    const res = await axios.post("https://localhost:5011/api/Category",props,{
        headers: { "Content-Type": "multipart/form-data" },      
            })
    return res
}

export const getobject = async(props)=>{
    const res = await axios.get(`https://localhost:5011/api/Category/${props}`)
    return res.data
}

export const edit = async(props)=>{
    const res = await axios.put(`https://localhost:5011/api/Category`,props,{
                                                                    headers: { "Content-Type": "multipart/form-data" },      
                                                                        })
    return res
}

