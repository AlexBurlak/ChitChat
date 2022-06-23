import './Chatblock.scss';

export function Chatblock(props) {
    return (
        <div className="chat-block">
            <div className="image-block">
                <div className="image text-black"><i className="bi bi-person-circle"></i></div>
            </div>
            <div className="text-section">
                <div className="chat-title">
                    <b className="text-dark">{props.title}</b>
                </div>
                <div className="chat-message">
                    <span className="text-black">{props.message}</span>
                </div>
            </div>
        </div>
    );
}