import { MouseEvent } from "react";
import { deleteNote, Note as NoteInterface } from "../lib/notes";
import './Note.css'

interface Props {
    note: NoteInterface,
    noteDeleted: (id: number) => void
}

export default function Note({ note, noteDeleted }: Props) {

    function deleteClick(e: MouseEvent<HTMLButtonElement>) {
        e.preventDefault();
        deleteNote(note.id)
            .then(success => {
                if (success) {
                    noteDeleted(note.id);
                }
            })
    }

    return (
        <li>
            <div className="note">
                <button className="noteDelete" onClick={e => deleteClick(e)}>Delete</button>
                <p className="noteHeader">{note.name}</p>
                <p className="noteContent">{note.content}</p>
            </div>
        </li>
    )
}