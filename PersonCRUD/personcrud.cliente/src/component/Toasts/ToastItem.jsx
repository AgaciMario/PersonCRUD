import Toast from 'react-bootstrap/Toast'
import { useState } from 'react'

function ToastItem({ toastData, idx }) {
    const [show, setShow] = useState(true);

    return (
        <Toast bg={toastData.type} key={idx} onClose={() => setShow(false)} show={show} delay={5000} autohide>
            <Toast.Header>
                <i className={`bi ${toastData.biIcon} me-2`}></i>
                <strong className="me-auto">{toastData.title}</strong>
                <small>11 mins ago</small>
            </Toast.Header>
            <Toast.Body className={toastData.type === "warning" ? "" : "text-white"}>{toastData.body}</Toast.Body>
        </Toast>
    )
}

export default ToastItem