import axios from "axios"

export interface Note {
    id: number,
    name: string,
    content: string
}

export interface NoteDto {
    name: string,
    content: string
}

const API_ENDPOINT = process.env.REACT_APP_API_ENDPOINT!;

export async function loadNotes(page: number | undefined): Promise<Note[]> {
    if (!page) {
        page = 1;
    }


    const notes = await axios.get<Note[]>(`${API_ENDPOINT}/api/notes?page=${page}`);
    return notes.data;
}

export async function deleteNote(id: number): Promise<boolean> {

    const success = await axios.delete(`${API_ENDPOINT}/api/notes/delete/${id}`)
        .then(() => true)
        .catch(e => {
            return e.response.status === 404;
        });

    return success;
}

export async function addNote(note: NoteDto): Promise<boolean> {
    return await axios.post(`${API_ENDPOINT}/api/notes/add`, note)
        .then(() => true)
        .catch(() => false);
}