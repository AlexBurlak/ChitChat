import { Input } from "reactstrap";
import './Searchblock.scss';
import { useDispatch } from "react-redux";
import { search } from '../../stores/chats/chats.slice';

export function Searchblock() {
    const dispatch = useDispatch();

    function HandleChange(event) {
        event.preventDefault();
        const target = event.target;
        dispatch(search(target.value));
    }

    return (
        <div className="search-block">
            <Input onChange={HandleChange} className="search-input text-dark fs-5" placeholder="Search..."/>
        </div>
    );
}