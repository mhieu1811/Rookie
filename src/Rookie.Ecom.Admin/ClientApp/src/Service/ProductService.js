import axios from "axios"
export const getList = async()=>{
    const res = await axios.get("https://localhost:5011/api/Product")
    return res.data
}

export const add = async(props)=>{
    const res = await axios.post("https://localhost:5011/api/Product",props,{
        headers: { "Content-Type": "multipart/form-data" },      
            })
    return res
}

export const getobject = async(props)=>{
    const res = await axios.get(`https://localhost:5011/api/Product/${props}`)
    return res.data
}

export const editpro = async(props)=>{
    const res = await axios.put(`https://localhost:5011/api/Product`,props,{
                                                                    headers: { "Content-Type": "multipart/form-data" },      
                                                                        })
    return res
}

