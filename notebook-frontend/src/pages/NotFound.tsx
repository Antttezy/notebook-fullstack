import { Link } from "react-router-dom"

export default function NotFound() {
    return (
        <>
            <p>
                <span>Page not found</span>
            </p>
            <span>Return to <Link to={'/'}>Main page</Link></span>
        </>
    )
}