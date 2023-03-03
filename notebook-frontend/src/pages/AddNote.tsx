import { ChangeEvent, MouseEvent, useState } from "react"
import { Navigate } from "react-router-dom";
import { addNote, NoteDto } from "../lib/notes";

export default function AddNote() {
    const [name, setName] = useState('');
    const [content, setContent] = useState('');
    const [success, setSuccess] = useState(false);

    function nameChanged(e: ChangeEvent<HTMLInputElement>) {
        e.preventDefault();
        setName(e.target.value);
    }

    function contentChanged(e: ChangeEvent<HTMLInputElement>) {
        e.preventDefault();
        setContent(e.target.value);
    }

    function noteSubmit(e: MouseEvent<HTMLButtonElement>) {
        e.preventDefault();
        const note: NoteDto = {
            name,
            content
        }

        addNote(note)
            .then(success => {
                setSuccess(success);
            });
    }

    return (
        <div>
            {success ? <Navigate to={'/'} /> : null}
            <input type='text' value={name} placeholder='Name' onChange={nameChanged} />
            <input type='text' value={content} placeholder='Content' onChange={contentChanged} />
            <button disabled={name === '' || content === ''} onClick={noteSubmit}>Submit</button>
        </div>
    )
}