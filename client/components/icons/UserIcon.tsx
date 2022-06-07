import React from 'react'

interface UserIconProps {
    onClick?: () => void;
  }
  

const UserIcon = ({ onClick }: UserIconProps) => {
  return (
    <a onClick={onClick}>
      <span className="user-icon"></span>
    </a>
  )
}

export default UserIcon