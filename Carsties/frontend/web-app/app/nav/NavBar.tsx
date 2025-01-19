import Search from "@/app/nav/Search";
import Logo from "@/app/nav/Logo";
import LoginButton from "@/app/nav/LoginButton";
import {getCurrentUser} from "@/app/auctions/authActions";
import UserActions from "@/app/nav/UserActions";


export default async function Navbar() {
    const user = await getCurrentUser();

    return (
        <header className="sticky top-0 z-50 flex items-center justify-between p-5 text-gray-800 bg-white shadow-md">
            <Logo/>
            <Search/>
            {user ? (
                <UserActions user={user} />
            ) : (
                <LoginButton />
            )}
        </header>
    );
}
