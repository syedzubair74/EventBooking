"use client";

import { getAllEvents } from "@/api";
import { useEffect } from "react";

const AllEvents = () => {
    useEffect(() => {
        fetchEvents()
    }, [])
    const fetchEvents = () => {
        getAllEvents().then(response => {
            console.log("reponse: ", response)
        })
    }
    return(
        <>
        <div>All Events Here</div>
        </>
    )

}
export default AllEvents