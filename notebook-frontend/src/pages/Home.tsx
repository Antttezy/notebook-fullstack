import NoteList from "../components/NoteList";
import { Navigate } from "react-router-dom";
import './Home.css'
import { MouseEvent, useState } from "react";

export default function Home() {
    const [add, setAdd] = useState(false);

    function addClick(e: MouseEvent<HTMLButtonElement>) {
        e.preventDefault();
        setAdd(true);
    }

    return (
        <div>
            {add ? <Navigate to={'/add'} /> : null}
            <button className="addNote" onClick={addClick}>Add Note</button>
            <NoteList />
        </div>
    )
}