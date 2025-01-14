import Search from "@/app/nav/Search";
import Logo from "@/app/nav/Logo";


export default function Navbar() {
    return (
        <header className="sticky top-0 z-50 flex items-center justify-between p-5 text-gray-800 bg-white shadow-md">
            <Logo/>
            <Search/>
            <div>Login</div>
        </header>
    );
}
