import ToastContainerb from 'react-bootstrap/ToastContainer'
import ToastItem from './ToastItem'
import { useState, useEffect } from 'react'

function ToastContainer({ notificationQueue }) {
    const [toastList, settoastList] = useState([])
    useEffect(() => settoastList(notificationQueue.map((toast, idx) => <ToastItem toastData={toast} key={idx} />)), [notificationQueue])

    return (
        <>
            <ToastContainerb className="p-3" position="top-end" style={{ zIndex: 999999 }}>
                {toastList}
            </ToastContainerb>
        </>
    )
}

export default ToastContainer
