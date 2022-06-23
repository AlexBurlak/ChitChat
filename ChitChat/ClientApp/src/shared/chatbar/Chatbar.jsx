import { useSelector } from 'react-redux';
import { Chatblock } from '../chatblock/Chatblock';
import { Searchblock } from  '../searchblock/Searchblock';
import './Chatbar.scss';

export function Chatbar(props) {
    const chats = useSelector(state => state.chats.chats);
    const searchString = useSelector(state => state.chats.searchString);
    const filteredChats = chats.filter(c => c.title.includes(searchString));

    return (
        <div className="chatbar">
            <Searchblock />
            {
                filteredChats.map(element => {
                    return <Chatblock key={element.title} title={element.title} message={element.message} />;
                })
            }
        </div>
    );
}