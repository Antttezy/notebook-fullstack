import { useEffect, useState } from "react"
import { loadNotes, Note } from "../lib/notes"
import NoteComponent from "./Note";
import './NoteList.css'

export default function NoteList() {
    const [notes, setNotes] = useState<Note[]>([]);

    useEffect(() => {
        loadNotes(undefined).then(notes => {
            setNotes(notes)
        }).catch(e => {
            console.error(e)
        });
    }, []);

    function noteDeleted(id: number) {
        setNotes(notes => notes.filter(note => note.id !== id))
    }

    return (
        <div className="noteList">
            <ul>
                {notes.map(note => <NoteComponent key={note.id} note={note} noteDeleted={noteDeleted} />)}
            </ul>
        </div>
    )
}