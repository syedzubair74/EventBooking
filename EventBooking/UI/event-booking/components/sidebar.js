"use client";
import React, { useState } from 'react';
import {
    MenuFoldOutlined,
    MenuUnfoldOutlined,
    UploadOutlined,
    UserOutlined,
    VideoCameraOutlined,
} from '@ant-design/icons';
import {
    House,
    File,
    Search,
    Maximize,
    Bolt,
    Mail,
    LogOut,
    SwatchBook,
} from "lucide-react";
import Image from "next/image";
import logo from "../public/images/logo.png";

import { Button, Layout, Menu, theme } from 'antd';
import AllEvents from './allevents';

const { Header, Sider, Content } = Layout;

const Sidebar = () => {
    const [collapsed, setCollapsed] = useState(false);
    const [selectedKey, setSelectedKey] = useState("1");

    const toggleCollapsed = () => {
        setCollapsed(!collapsed);
    };

    const handleClick = (key) => {
        setSelectedKey(key);
    };

    const items = [
        {
            label: "All Events",
            icon: <File />,
            component: (
                <>
                    <AllEvents />
                </>
            ),
            key: "1",
        },
        {
            label: "Insert Event",
            component: (
                <>
                    <div>Insert Event</div>
                </>
            ),
            icon: <File />,
            key: "2",
        },
        {
            label: "All Users",
            component: (
                <>
                    <div>All Users</div>
                </>
            ),
            icon: <Search />,
            key: "3",
        },
        {
            label: "About",
            component: (
                <>
                    <div>About</div>
                </>
            ),
            icon: <Maximize />,
            key: "4",
        },
        {
            label: "Logout",
            component: (
                <>
                    <div>Logout</div>
                </>
            ),
            icon: <Bolt />,
            key: "5",
        },

    ];

    const renderContent = () => {
        const selectedItem = items.find((item) => item.key === selectedKey);
        return selectedItem ? (
            <div className="flex w-full mt-[96px] px-[14px] bg-white">
                {selectedItem.component}
            </div>
        ) : (
            <div>404 - Not Found</div>
        );
    };

    return (
        <div className="flex w-full absolute">
            <div
                className={`z-10 h-screen bg-white flex flex-col font-inter ${collapsed ? "w-20" : "w-[280px]"
                    }`}
            >
                <div className="w-[280px]">
                    <div className="flex py-2">
                        <Image
                            src={logo}
                            width={80}
                            height={39}
                            className="flex justify-center"
                        />
                    </div>
                    <div className="flex flex-col bg-gray-100 h-screen">
                        {items.map((item) => (
                            <div
                                key={item.key}
                                onClick={() => handleClick(item.key)}
                                className={`flex items-center text-base  gap-3  cursor-pointer  ${collapsed
                                    ? "w-20  justify-center items-center align-middle flex"
                                    : "w-[280px] pl-[40px]"
                                    } ${selectedKey === item.key
                                        ? "bg-[#113493] text-white"
                                        : "text-black"
                                    }`}
                                style={{ height: "80px", opacity: "0.8" }}
                            >
                                {item.icon}
                                {!collapsed && (
                                    <span className="font-medium">{item.label}</span>
                                )}
                            </div>
                        ))}
                    </div>
                </div>
            </div>

            <div className="flex w-full">{renderContent()}</div>
        </div>
    );
};

export default Sidebar;